using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;

public class DiscountDTO
{
    public int DiscountId { get; set; }

    public string Name { get; set; }
    
    public decimal Value { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}