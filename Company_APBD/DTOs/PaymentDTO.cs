using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;

public class PaymentDTO
{
    public int PaymentId { get; set; }
    
    public int ContractId { get; set; }
    
    public int CustomerId { get; set; }
    
    public decimal Amount { get; set; }
    
    public DateTime PaymentDate { get; set; }
}