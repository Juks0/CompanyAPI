using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;

public class DiscountDTO
{
    public int DiscountId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Discount type is required")]
    public string DiscountType { get; set; }

    [Range(0, 100, ErrorMessage = "Value must be between 0 and 100")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "Start date is required")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is required")]
    public DateTime EndDate { get; set; }
}