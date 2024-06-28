using System;
using System.Linq;
using System.Threading.Tasks;
using Company_APBD.Data;
using Microsoft.EntityFrameworkCore;
using Company_APBD.DTOs;
using Company_APBD.Models;
using Microsoft.Extensions.Logging;
using WebApplication5.Exceptions;

namespace Company_APBD.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(DatabaseContext context, ILogger<UserService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task<bool> DoesCompanyCustomerExist(int id)
        {
            return await _context.CompanyCustomer.AnyAsync(c => c.CustomerID == id);
        }
        public async Task<bool> DoesIndividualCustomerExist(int id)
        {
            return await _context.IndividualCustomer.AnyAsync(c => c.CustomerID == id);
        }
        public async Task<CompanyCustomer> GetCompanyCustomer(int id)
        {
            var customer = await _context.CompanyCustomer.FindAsync(id);
            if (!await DoesCompanyCustomerExist(id))
            {
                throw new ReasourceNotFound($"There is no company customer with id {id}");
            }
            if (customer.IsDeleted)
            {
                throw new ReasourceNotFound($"Customer with id {id} got deleted from database");
            }

            return customer;
                
        }
        
        public async Task<IndividualCustomer> GetIndividualCustomer(int id)
        {
            var customer = await _context.IndividualCustomer.FindAsync(id);

            if (!await DoesIndividualCustomerExist(id))
            {
                throw new ReasourceNotFound($"There is no individual customer with id {id}");
            }
            if (customer.IsDeleted)
            {
                throw new ReasourceNotFound($"Customer with id {id} got deleted from database");
            }

            return customer;
        }

  
        public async Task<CompanyCustomer> UpdateCompanyCustomer(CompanyCustomerDTO companyCustomer){

            try
            {
                if (!await DoesCompanyCustomerExist(companyCustomer.CustomerId))
                {
                    if (await DoesIndividualCustomerExist(companyCustomer.CustomerId))
                    {
                        throw new WrongReasourceException(
                            $"Customer with id {companyCustomer.CustomerId} is an Individual Customer, not a Company Customer.");
                    }
                    throw new ReasourceNotFound(
                        $"There is no company customer with id {companyCustomer.CustomerId}");
                }

                var companyCustomerToUpdate = await _context.CompanyCustomer.FindAsync(companyCustomer.CustomerId);
            
                companyCustomerToUpdate.Email = companyCustomer.Email;
                companyCustomerToUpdate.PhoneNumber = companyCustomer.PhoneNumber;
                companyCustomerToUpdate.Address = companyCustomer.Address;
                companyCustomerToUpdate.CompanyName = companyCustomer.CompanyName;
                companyCustomerToUpdate.KRS = companyCustomer.KRS;
            
                await _context.SaveChangesAsync();
            
                return companyCustomerToUpdate;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while updating company customer with ID {companyCustomer.CustomerId}: {ex.Message}");
                throw;
            }
        }
        
        public async Task<IndividualCustomer>UpdateIndividualCustomer(IndividualCustomerDTO individualCustomer)
        {
            try
            {
                if (!await DoesIndividualCustomerExist(individualCustomer.CustomerId))
                {
                    if (await DoesCompanyCustomerExist(individualCustomer.CustomerId))
                    {
                        throw new WrongReasourceException(
                            $"Customer with id {individualCustomer.CustomerId} is a Company Customer, not an Individual Customer.");
                    }

                    throw new ReasourceNotFound(
                        $"There is no individual customer with {individualCustomer.CustomerId}");
                }

                var individualCustomerToUpdate = await _context.IndividualCustomer.FindAsync(individualCustomer.CustomerId);
            
                individualCustomerToUpdate.Email = individualCustomer.Email;
                individualCustomerToUpdate.PhoneNumber = individualCustomer.PhoneNumber;
                individualCustomerToUpdate.Address = individualCustomer.Address;
                individualCustomerToUpdate.FirstName = individualCustomer.FirstName;
                individualCustomerToUpdate.LastName = individualCustomer.LastName;
                individualCustomerToUpdate.PESEL = individualCustomer.PESEL;
            
                await _context.SaveChangesAsync();
            
                return individualCustomerToUpdate;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while updating individual customer with ID {individualCustomer.CustomerId}: {ex.Message}");
                throw;
            }
        }
       
        public async Task<CompanyCustomer> AddCompanyCustomer(CompanyCustomerNoIDDTO companyCustomerDTO)
        {
            try
            {
                var companyCustomer = new CompanyCustomer
                {
                    CompanyName = companyCustomerDTO.CompanyName,
                    KRS = companyCustomerDTO.KRS,
                    Address = companyCustomerDTO.Address,
                    Email = companyCustomerDTO.Email,
                    PhoneNumber = companyCustomerDTO.PhoneNumber
                };
        
                _context.Add(companyCustomer);
                await _context.SaveChangesAsync();
        
                return companyCustomer;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while adding company customer: {ex.Message}");
                throw;
            }
        }

        public async Task<IndividualCustomer> AddIndividualCustomer(IndividualCustomerNoIDDTO individualCustomer)
        {
            try
            {
                var newIndividualCustomer = new IndividualCustomer()
                {
                    FirstName = individualCustomer.FirstName,
                    LastName = individualCustomer.LastName,
                    PESEL = individualCustomer.PESEL,
                    Address = individualCustomer.Address,
                    Email = individualCustomer.Email,
                    PhoneNumber = individualCustomer.PhoneNumber
                };
        
                _context.Add(newIndividualCustomer);
                await _context.SaveChangesAsync();
        
                return newIndividualCustomer;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while adding company customer: {ex.Message}");
                throw;
            }
        }
        
        public async Task<bool> DeleteCompanyCustomer(int id)
        {
            try
            {
                var companyCustomer = await _context.FindAsync<CompanyCustomer>(id);
        
                if (companyCustomer == null)
                {
                    _logger.LogWarning($"Company customer with ID {id} not found.");
                    return false;
                }
               companyCustomer.IsDeleted= true;
               
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while deleting company customer with ID {id}: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeleteIndividualCustomer(int id)
        {
            try
            {
                var individualCustomer = await _context.FindAsync<IndividualCustomer>(id);
        
                if (individualCustomer == null)
                {
                    _logger.LogWarning($"Company customer with ID {id} not found.");
                    return false;
                }
                individualCustomer.IsDeleted= true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while deleting company customer with ID {id}: {ex.Message}");
                throw;
            }
        }
    }
}
