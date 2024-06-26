using Company_APBD.DTOs;
using Company_APBD.Models;
using Company_APBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company_APBD.Controllers;

public class SoftwareControllerCompany : ControllerBase
{
    private readonly ISoftwareServiceCompany _softwareServiceCompany;

    public SoftwareControllerCompany(ISoftwareServiceCompany softwareService)
    {
        _softwareServiceCompany = softwareService;
    }

    [HttpPost("/createContractCompany")]
    public async Task<IActionResult> CreateContract([FromBody]AddNewContractDTO contract)
    {
        try
        {
            var result = await _softwareServiceCompany.CreateContractCompanyCustomer(contract);
            return Ok(result);
        }
        
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }
    [HttpGet("/getSoftwareInfoCompany/{id}")]
    public async Task<IActionResult> GetSoftwareInfo(int id)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest("Invalid software ID.");
            }
    
            var result = await _softwareServiceCompany.GetSoftwareById(id);
    
            if (result == null)
            {
                return NotFound($"Software with ID {id} not found.");
            }
    
            return Ok(result);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest($"Invalid argument: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            return NotFound($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpGet("/getDiscountInfoCompany/{id}")]
    public async Task<IActionResult> GetDiscountInfo(int id)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest("Invalid discount ID.");
            }

            var result = await _softwareServiceCompany.GetDiscountInfo(id);

            if (result == null)
            {
                return NotFound($"Discount with ID {id} not found.");
            }

            return Ok(result);
        }
        catch (ArgumentNullException ex)
        {
            // Log the exception (optional)
            return BadRequest($"Invalid argument: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            // Log the exception (optional)
            return NotFound($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpPost("/payForContractCompany")]
    public async Task<IActionResult> PayForContract([FromBody]PayforContractDTO payforContract)
    {
        try
        {
            var result = await _softwareServiceCompany.PayForContract(payforContract);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }
    [HttpGet("/getContractCompany/{contractId}")]
    public async Task<IActionResult> GetContract(int contractId)
    {
        try
        {
            if (contractId <= 0)
            {
                return BadRequest("Invalid contract ID.");
            }

            var result = await _softwareServiceCompany.GetContract(contractId);

            if (result == null)
            {
                return NotFound($"Contract with ID {contractId} not found.");
            }

            return Ok(result);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest($"Invalid argument: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            return NotFound($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}