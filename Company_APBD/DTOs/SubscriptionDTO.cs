using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;

public class SubscriptionDTO
{
    [Required]
    public int SubscriptionId { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
    
    [Required]
    public int SoftwareId { get; set; }
    
    [Required]
    public string RenewalPeriod { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    [Required]
    public int DiscountId { get; set; }
}