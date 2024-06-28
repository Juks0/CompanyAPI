using Company_APBD.Data;
using Company_APBD.DTOs;
using Company_APBD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebApplication5.Exceptions;

namespace Company_APBD.Services
{
    public class SoftwareServiceIndividual : ISoftwareServiceIndividual
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<ISoftwareServiceIndividual> _logger;

        public SoftwareServiceIndividual(DatabaseContext context, ILogger<ISoftwareServiceIndividual> logger)
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
            var customerExists = await _context.IndividualCustomer.AnyAsync(c => c.CustomerID == id);
            var customer = await _context.IndividualCustomer.FindAsync(id);

            if (!customerExists)
            {
                throw new ReasourceNotFound($"Customer with ID {id} does not exist.");
            }

            if (customer.IsDeleted)
            {
                throw new ReasourceNotFound($"Customer with ID {id} has been deleted.");
            }
            {
                
            }

            return customerExists;
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
                throw new ReasourceNotFound($"Software with ID {id} not found.");
            }

            return software;
        }

        public async Task<ContractIndividualCustomer> CreateContractInvidualCustomer(AddNewContractDTO contractDto)
        {
            try
            {
                await DoesCustomerExist(contractDto.CustomerId);
                await ValidateContractDates(contractDto.StartDate, contractDto.EndDate);
                await CheckDoesCustomerHaveContractForSoftware(contractDto.CustomerId, contractDto.SoftwareId);
                var discount = await GetDiscountInfo(contractDto.DiscountId);
                var software = await GetSoftwareById(contractDto.SoftwareId);
                if (await doesCustomerHaveContract(contractDto.CustomerId))
                {
                   discount.Value  += 0.05m;
                }
                
                var newContract = new ContractIndividualCustomer()
                {
                    SoftwareID = contractDto.SoftwareId,
                    discountID = contractDto.DiscountId,
                    IndividualCustomerID = contractDto.CustomerId,
                    startDate = contractDto.StartDate,
                    endDate = contractDto.EndDate,
                    ContactLength = contractDto.SupportYears,
                    Price = software.Price,
                    TotalToPay =( software.Price - (software.Price * discount.Value))+ ((contractDto.SupportYears-1)*1000),
                    isActive = false
                };

                await _context.ContractIndividualCustomers.AddAsync(newContract);
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
                throw new Exception("An error occurred while adding a new contract. See inner exception for details.",
                    ex);
            }
        }

        private async Task CheckDoesCustomerHaveContractForSoftware(int customerId, int softwareId)
        {
            bool hasContract = await _context.ContractIndividualCustomers.AnyAsync(c =>
                c.IndividualCustomerID == customerId && c.SoftwareID == softwareId);

            if (hasContract)
            {
                throw new AlreadyHasSoftwareException(
                    "The customer have a contract for the specified software.");
            }
        }

        private async Task ValidateContractDates(DateTime startDate, DateTime endDate)
        {
            var differenceInDays = (endDate - startDate).TotalDays;

            if (startDate >= endDate)
            {
                throw new WrongTimePeriodException("The start date must be before the end date.");
            }

            if (differenceInDays < 3 || differenceInDays > 30)
            {
                throw new WrongTimePeriodException(
                    "The difference between StartDate and EndDate must be between 3 and 30 days.");
            }
        }

        public async Task<ContractIndividualCustomer> PayForContract(PayforContractDTO payforContractDto)
        {
            try
            {
                var contract = await getContract(payforContractDto.contractID);
        
                if (contract.isPaid == contract.TotalToPay)
                {
                    throw new ContractIsPaidException("Contract is already paid.");
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
                    throw new TooMuchMoneyException("The payment amount exceeds the total amount to pay.");
                }

                await _context.SaveChangesAsync();
                return contract;
            }
         
            catch (ApplicationException)
            {
                
                var contract = await getContract(payforContractDto.contractID);
                await GetCustomerById(contract.IndividualCustomerID); 
        
                throw; 
            }
        }
        private async Task<bool> doesCustomerHaveContract(int customerId)
        {
            bool hasContract = await _context.ContractIndividualCustomers.AnyAsync(c =>
                c.IndividualCustomerID == customerId);

           return hasContract;
        }
        public async Task<ContractIndividualCustomer> getContract(int contractId)
        {
            var contract = await _context.ContractIndividualCustomers.FirstOrDefaultAsync(c =>
                c.ContractID == contractId);

            if (contract == null)
            {
                throw new ReasourceNotFound($"Contract with ID {contractId} not found.");
            }

            if (contract.endDate < DateTime.Now)
            {
                throw new ReasourceNotFound("Contract has expired.");
            }

            return contract;
        }
        private async Task<IndividualCustomer> GetCustomerById(int id)
        {
            var customer = await _context.IndividualCustomer.FindAsync(id);

            if (customer == null)
            {
                throw new ReasourceNotFound($"Customer with ID {id} not found.");
            }

            return customer;
        }
    }
}