using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models;

public class Contract
{
    public int ContractId { get; set; }
    public int CustomerId { get; set; }
    public int SoftwareId { get; set; }
    public string Version { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public int DiscountId { get; set; }
    public int SupportYears { get; set; }
    public bool IsSigned { get; set; }

   
}