using Company_APBD.DTOs;
using Company_APBD.Models;

namespace Company_APBD.Services
{
    public interface IUserService
    {
        Task<CompanyCustomer> AddCompanyCustomer(CompanyCustomerNoIDDTO companyCustomer);
        Task<CompanyCustomer> UpdateCompanyCustomer(CompanyCustomerDTO companyCustomer);
        Task<IndividualCustomer> UpdateIndividualCustomer(IndividualCustomerDTO companyCustomer);
        Task<IndividualCustomer> AddIndividualCustomer(IndividualCustomerNoIDDTO individualCustomer);
        Task<bool> DeleteCustomer(int id);
        Task<IndividualCustomer> GetIndividualCustomer(int id);
        Task<CompanyCustomer> GetCompanyCustomer(int id);
        


    }
}