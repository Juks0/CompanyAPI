using Company_APBD.DTOs;
using Company_APBD.Models;
using Company_APBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company_APBD.Controllers;

public class SoftwareControllerIndividual : ControllerBase
{
    private readonly ISoftwareServiceIndividual _softwareServiceIndividual;

    public SoftwareControllerIndividual(ISoftwareServiceIndividual softwareServiceIndividual)
    {
        _softwareServiceIndividual = softwareServiceIndividual;
    }

    [HttpPost("/createContractIndividual")]
    public async Task<IActionResult> CreateContract([FromBody]AddNewContractDTO contract)
    {
        try
        {
            var result = await _softwareServiceIndividual.CreateContractInvidualCustomer(contract);
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

            var result = await _softwareServiceIndividual.GetSoftwareById(id);

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
    [HttpGet("/getDiscountInfo/{id}")]
    public async Task<IActionResult> GetDiscountInfo(int id)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest("Invalid discount ID.");
            }

            var result = await _softwareServiceIndividual.GetDiscountInfo(id);

            if (result == null)
            {
                return NotFound($"Discount with ID {id} not found.");
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
    [HttpPost("/payForContract")]
    public async Task<IActionResult> PayForContract([FromBody]PayforContractDTO payforContractDTO)
    {
        try
        {
            var result = await _softwareServiceIndividual.PayForContract(payforContractDTO);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }
    [HttpGet("/getContract/{contractId}")]
    public async Task<IActionResult> GetContract(int contractId)
    {
        try
        {
            if (contractId <= 0)
            {
                return BadRequest("Invalid contract ID.");
            }

            var result = await _softwareServiceIndividual.getContract(contractId);

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