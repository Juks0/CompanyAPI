using System;
using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        public string CustomerType { get; set; }

        public string Address { get; set; }


        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}