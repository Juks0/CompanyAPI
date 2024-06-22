using System;
using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer type is required")]
        public string CustomerType { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
    }
}