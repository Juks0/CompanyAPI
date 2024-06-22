using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;

public class PaymentDTO
{
    [Required]
    public int PaymentId { get; set; }
    
    [Required]
    public int ContractId { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
    
    [Required]
    public decimal Amount { get; set; }
    
    [Required]
    public DateTime PaymentDate { get; set; }
}