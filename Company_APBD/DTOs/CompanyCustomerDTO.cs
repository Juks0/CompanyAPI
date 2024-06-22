
using System.ComponentModel.DataAnnotations;
using Company_APBD.DTOs;

public class CompanyCustomerDTO : CustomerDTO
{
    [Required(ErrorMessage = "Company name is required")]
    public string CompanyName { get; set; }

    [Required(ErrorMessage = "KRS is required")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "KRS must be exactly 10 characters")]
    public string KRS { get; set; }
}