using Company_APBD.Data;
using Company_APBD.DTOs;
using Company_APBD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Company_APBD.Services
{
    public class SoftwareServiceCompany : ISoftwareServiceCompany
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<ISoftwareServiceCompany> _logger;

        public SoftwareServiceCompany(DatabaseContext context, ILogger<ISoftwareServiceCompany> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> DoesContractExist(int id)
        {
            if (await _context.ContractIndividualCustomers.AnyAsync(c => c.ContractID == id))
            {
                return true;
            }
            return await _context.ContractCompanyCustmers.AnyAsync(c => c.ContractID == id);
        }

        public async Task<bool> DoesCustomerExist(int id)
        {
            if (await _context.IndividualCustomer.AnyAsync(c => c.CustomerID == id))
            {
                return true;
            }
            return await _context.ContractCompanyCustmers.AnyAsync(c => c.CompanyCustomer.CustomerID == id);
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

        public async Task<ContractCompanyCustmer> CreateContractCompanyCustomer(AddNewContractDTO contractDto)
        {
            try
            {
                await DoesCustomerExist(contractDto.CustomerId);
                await ValidateContractDates(contractDto.StartDate, contractDto.EndDate);
                await CheckDoesCustomerHaveContractForSoftware(contractDto.CustomerId, contractDto.SoftwareId);
                var discount = await GetDiscountInfo(contractDto.DiscountId);
                var software = await GetSoftwareById(contractDto.SoftwareId);
                
                var newContract = new ContractCompanyCustmer()
                {
                    CompanyCustomerID = contractDto.CustomerId,
                    SoftwareID = contractDto.SoftwareId,
                    startDate = contractDto.StartDate,
                    endDate = contractDto.EndDate,
                    ContactLength = contractDto.SupportYears,
                    Price = software.Price,
                    discountID = contractDto.DiscountId,
                    TotalToPay =( software.Price - (software.Price * discount.Value))+ ((contractDto.SupportYears-1)*1000),
                    isActive = false
                };

                await _context.ContractCompanyCustmers.AddAsync(newContract);
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

        public async Task<ContractCompanyCustmer> PayForContract(PayforContractDTO payforContractDto)
        {
            try
            {
                var contract = await GetContract(payforContractDto.contractID);

                if (contract.isPaid == contract.TotalToPay)
                {
                    throw new InvalidOperationException("Contract is already paid.");
                }

                decimal remainingAmountToPay = contract.TotalToPay - contract.isPaid;

                if (payforContractDto.paymentAmount <= remainingAmountToPay)
                {
                    contract.isPaid += payforContractDto.paymentAmount;

                    if (contract.isPaid == contract.TotalToPay)
                    {
                        contract.isActive = true;
                    }
                }
                else
                {
                    throw new InvalidOperationException("The payment amount exceeds the total amount to pay.");
                }

                await _context.SaveChangesAsync();
                return contract;
            }
            catch (ApplicationException)
            {
                var contract = await GetContract(payforContractDto.contractID);
                await GetCustomerById(contract.CompanyCustomerID);

                throw;
            }
        }
        private async Task ValidateContractDates(DateTime startDate, DateTime endDate)
        {
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
        }
        public async Task<ContractCompanyCustmer> GetContract(int contractId)
        {
            var contract = await _context.ContractCompanyCustmers.FirstOrDefaultAsync(c =>
                c.ContractID == contractId);

            if (contract == null)
            {
                throw new InvalidOperationException($"Contract with ID {contractId} not found.");
            }

            if (contract.endDate < DateTime.Now)
            {
                throw new ApplicationException("Contract has expired.");
            }

            return contract;
        }

        private async Task<IndividualCustomer> GetCustomerById(int id)
        {
            var customer = await _context.IndividualCustomer.FindAsync(id);

            if (customer == null)
            {
                throw new InvalidOperationException($"Customer with ID {id} not found.");
            }

            return customer;
        }

        private async Task CheckDoesCustomerHaveContractForSoftware(int customerId, int softwareId)
        {
            if (await _context.ContractCompanyCustmers.AnyAsync(c =>
                c.CompanyCustomerID == customerId && c.SoftwareID == softwareId))
            {
                throw new InvalidOperationException("Customer already has a contract for this software.");
            }
        }
        
    }
}
