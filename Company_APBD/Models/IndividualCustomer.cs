using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models
{
    public class IndividualCustomer 
    {
        [Key]
        public int CustomerID { get; set; }
        
        [Required]
        [Column("Adress")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Column("Email")]
        public string Email { get; set; }

        [Column("PhoneNumber")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        
        [Required]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required]
        [Column("PESEL")]
        [StringLength(11)]
        public string PESEL { get; set; }
        
        public bool IsDeleted { get; set; } = false;
        
        public ICollection<ContractIndividualCustomer> ContractIndividualCustomer { get; set; }


    }
}