using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models;


public class CompanyCustomer : Customer
{
    
    [Required(ErrorMessage = "Company name is required")]
    public string CompanyName { get; set; }
    
    [Required(ErrorMessage = "KRS number is required")]
    public string KRS { get; set; }
}
