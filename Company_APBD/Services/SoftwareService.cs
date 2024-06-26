using Company_APBD.Data;
using Company_APBD.DTOs;
using Company_APBD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Company_APBD.ValidationAttributes;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Company_APBD.Services
{
    public class SoftwareService : ISoftwareService
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<SoftwareService> _logger;

        public SoftwareService(DatabaseContext context, ILogger<SoftwareService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> DoesContractExist(int id)
        {
            return await _context.Subscription.AnyAsync(c => c.CustomerId == id);
        }

        public async Task<bool> DoesCustomerExist(int id)
        {
            return await _context.Contract.AnyAsync(c => c.CustomerId == id);
        }

        public async Task<Discount> GetDiscountInfo(int id)
        {
            try
            {
                return await _context.Discount.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching discount information for discount ID {DiscountId}", id);
                throw;
            }
        }
        public async Task<Software> GetSoftwareById(int id)
        {
            var software = await _context.Software.FindAsync(id);
            if (software == null)
            {
                throw new InvalidOperationException($"Software with ID {id} not found.");
            }

            return software;
        }

        public async Task<Contract> CreateContract(AddNewContractDTO contractDto)
        {
            try
            {
                var startDate = contractDto.StartDate;
                var endDate = contractDto.EndDate;
                var differenceInDays = (endDate - startDate).TotalDays;

                if (startDate >= endDate)
                {
                    throw new InvalidOperationException("The start date must be before the end date.");
                }

                if (differenceInDays < 3 || differenceInDays > 30)
                {
                    throw new InvalidOperationException(
                        "The difference between StartDate and EndDate must be between 3 and 30 days.");
                }

                var discount = GetDiscountInfo(contractDto.DiscountId);
                var software = GetSoftwareById(contractDto.SoftwareId);

                var newContract = new Contract()
                {
                    SoftwareId = contractDto.SoftwareId,
                    CustomerId = contractDto.CustomerId,
                    StartDate = contractDto.StartDate,
                    EndDate = contractDto.EndDate,
                    SupportYears = contractDto.SupportYears,
                    Version = software.Result.CurrentVersion,
                    Price = software.Result.Price,
                    PriceAfterDiscount = (software.Result.Price + (contractDto.SupportYears - 1) * 1000) *
                                         discount.Result.Value /
                                         100,
                    DiscountId = contractDto.DiscountId,
                    IsSigned = false
                };

                _context.Add(newContract);
                await _context.SaveChangesAsync();

                return newContract;
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx,
                    "Database update error while adding contract for customer ID {CustomerId}. Details: {InnerException}",
                    contractDto.CustomerId, dbEx.InnerException?.Message);
                throw new Exception("A database update error occurred. See inner exception for details.", dbEx);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding contract for customer ID {CustomerId}: {Message}",
                    contractDto.CustomerId, ex.Message);
                throw;
            }
        }
    }
}