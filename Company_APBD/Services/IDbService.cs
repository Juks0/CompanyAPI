using Company_APBD.DTOs;

namespace Company_APBD.Services
{
    public interface IDbService
    {
        Task<CompanyCustomerDTO> AddCompanyCustomer(CompanyCustomerDTO companyCustomerDTO);
        Task<CompanyCustomerDTO> UpdateCompanyCustomer(CompanyCustomerDTO companyCustomerDTO);
        Task<CompanyCustomerDTO> DeleteCompanyCustomer(int id);
        Task<IndividualCustomerDTO> AddIndividualCustomer(IndividualCustomerDTO individualCustomerDTO);
        Task<IndividualCustomerDTO> UpdateIndividualCustomer(IndividualCustomerDTO individualCustomerDTO);
        Task<IndividualCustomerDTO> DeleteIndividualCustomer(int id);
        
    }
}