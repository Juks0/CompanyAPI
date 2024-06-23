namespace Company_APBD.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public Contract Contract { get; set; }
    public Customer Customer  { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

}