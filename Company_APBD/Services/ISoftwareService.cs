using Company_APBD.DTOs;
using Company_APBD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company_APBD.Services;

public interface ISoftwareService
{
    Task <Contract> CreateContract(AddNewContractDTO contractDto);
    Task<Software> GetSoftwareById(int id);
    Task<Discount> GetDiscountInfo(int id);

}