using Company_APBD.DTOs;
using Company_APBD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company_APBD.Services;

public interface ISoftwareServiceIndividual
{
    Task <ContractIndividualCustomer> CreateContractInvidualCustomer(AddNewContractDTO contractDto);
    Task<Software> GetSoftwareById(int id);
    Task<Discount> GetDiscountInfo(int id);
    Task<ContractIndividualCustomer> PayForContract(PayforContractDTO payforContractDTO);
    Task<ContractIndividualCustomer> getContract(int contractId);
}