using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs
{
    public class IndividualCustomerDTO : CustomerDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "PESEL is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "PESEL must be exactly 11 characters")]
        public string PESEL { get; set; }
    }
}