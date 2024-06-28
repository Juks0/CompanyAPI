using Company_APBD.DTOs;
using Company_APBD.Models;
using Company_APBD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company_APBD.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    

   
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        try
        {
            var user = await _userService.GetIndividualCustomer(id);
            return Ok(user);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [Authorize(Roles = "Admin")]
    [HttpDelete("/IndividualCustomer {id}")]
    public async Task<IActionResult> DeleteIndividualUser(int id)
    {
        
        var result = await _userService.DeleteIndividualCustomer(id);
        if (result)
        {
            return Ok("User deleted successfully.");
        }
        else
        {
            return NotFound("User not found.");
        }
    }
    [HttpDelete("/CompanyUser {id}")]
    public async Task<IActionResult> DeleteCompanyUser(int id)
    {
        
        var result = await _userService.DeleteCompanyCustomer(id);
        if (result)
        {
            return Ok("User deleted successfully.");
        }
        else
        {
            return NotFound("User not found.");
        }
    }
    [Authorize(Roles = "Admin")]
    [HttpPost("/updateCompanyCustomer")]
         public async Task<IActionResult>UpdateCompanyUser([FromBody] CompanyCustomerDTO companyCustomer)
         {
             try
             {
                 var result = await _userService.UpdateCompanyCustomer(companyCustomer);
                 return Ok(result);
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 throw;
             }
         }
    [Authorize(Roles = "Admin")]
    [HttpPost("/updateIndividualCustomer")]
    public async Task<IActionResult> UpdateIndividualUser([FromBody] IndividualCustomerDTO individualCustomer)
    {
        try
        {
            var result = await _userService.UpdateIndividualCustomer(individualCustomer);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
         
    [HttpPost("/addCompanyCustomer")]
    public async Task<IActionResult>AddCompanyCustomer(CompanyCustomerNoIDDTO companyCustomer)
    {
        var result = await _userService.AddCompanyCustomer(companyCustomer);
       
            return Ok("Company customer added successfully.");
       
    }
    [HttpPost("/addIndividualCustomer")]
    public async Task<IActionResult>AddIndvidualCustomer(IndividualCustomerNoIDDTO individualCustomer)
    {
        var result = await _userService.AddIndividualCustomer(individualCustomer);
       
            return Ok("Individual customer added successfully.");
       
    }
   
}