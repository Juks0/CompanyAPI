using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;

public class SubscriptionDTO
{
    public int SubscriptionId { get; set; }
    
    public int CustomerId { get; set; }
    
    public int SoftwareId { get; set; }
    
    public string RenewalPeriod { get; set; }
    
    public decimal Price { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public int DiscountId { get; set; }
}