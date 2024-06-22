using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;

public class ContractDTO
{
    [Required]
    public int ContractId { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
    
    [Required]
    public int SoftwareId { get; set; }  
    
    [Required]
    public string Version { get; set; } 
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; } 
    
    [Required]
    public decimal Price { get; set; } 
    
    [Required]
    public int DiscountId { get; set; } 
    
    [Required]
    public int SupportYears { get; set; } 
    
    [Required]
    public bool IsSigned { get; set; }    

}