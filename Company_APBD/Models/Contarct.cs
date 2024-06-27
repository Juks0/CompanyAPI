using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Company_APBD.ValidationAttributes;

namespace Company_APBD.Models;

public class Contract
{
    public int ContractId { get; set; }
    [Required]
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    [Required]
    [ForeignKey("SoftwareId")]
    public int SoftwareId { get; set; }
    [Required]
    public string Version { get; set; }
    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
    // Price is determined by SupportYears * Price of Software per year
    public decimal Price { get; set; }
    
    [ForeignKey("DiscountId")]
    public int DiscountId { get; set; }
    public decimal PriceAfterDiscount { get; set; }
    [Required]
    [Range(1, 4)]
    public int SupportYears { get; set; }
    public bool IsSigned { get; set; }

   
}