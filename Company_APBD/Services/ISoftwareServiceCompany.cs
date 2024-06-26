using Company_APBD.DTOs;
using Company_APBD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company_APBD.Services;

public interface ISoftwareServiceCompany

{
    Task <ContractCompanyCustmer> CreateContractCompanyCustomer(AddNewContractDTO contractDto);
    Task<Software> GetSoftwareById(int id);
    Task<Discount> GetDiscountInfo(int id);
    Task<ContractCompanyCustmer> PayForContract(PayforContractDTO payforContractDto);
    Task<ContractCompanyCustmer> GetContract(int contractId);

}