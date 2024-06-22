namespace Company_APBD.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public int ContractId { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    public Contract Contract { get; set; }
}