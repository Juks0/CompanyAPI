using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models;

[Table("discount")]
public class Discount
{
    public int DiscountId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string DiscountType { get; set; }

    [Required]
    [Range(0, 100)]
    public decimal Value { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
}