using System.ComponentModel.DataAnnotations;

namespace Company_APBD.Models;

public class IndividualCustomer : Customer
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [StringLength(11)]
    public string PESEL { get; set; }
}