namespace Company_APBD.Models;

public class Subscription
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