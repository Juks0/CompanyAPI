using Company_APBD.DTOs;
using Company_APBD.Models;
using Company_APBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company_APBD.Controllers;

public class SoftwareController : ControllerBase
{
    private readonly ISoftwareService _softwareService;

    public SoftwareController(ISoftwareService softwareService)
    {
        _softwareService = softwareService;
    }

    [HttpPost("/createContract")]
    public async Task<IActionResult> CreateContract(AddNewContractDTO contract)
    {
        try
        {
            var result = await _softwareService.CreateContract(contract);
            return Ok(result);
        }
        
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }
    [HttpGet("/getSoftwareInfo/{id}")]
    public async Task<IActionResult> GetSoftwareInfo(int id)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest("Invalid software ID.");
            }

            var result = await _softwareService.GetSoftwareById(id);

            if (result == null)
            {
                return NotFound($"Software with ID {id} not found.");
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
    [HttpGet("/getDiscountInfo/{id}")]
    public async Task<IActionResult> GetDiscountInfo(int id)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest("Invalid discount ID.");
            }

            var result = await _softwareService.GetDiscountInfo(id);

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

}