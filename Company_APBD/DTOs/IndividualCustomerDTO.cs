using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs
{
    public class IndividualCustomerDTO : CustomerDTO
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
     
        public string PESEL { get; set; }
    }
}