using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models
{
    public class CompanyCustomer 
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

        [Column("CompanyName")]
        [Required(ErrorMessage = "Company name is required")]
        public string CompanyName { get; set; }
        
        [Column("KRS")]
        [Required(ErrorMessage = "KRS number is required")]
        public string KRS { get; set; }
        public bool IsDeleted { get; set; } = false;

        
        public ICollection<ContractCompanyCustmer> ContractCompanyCustmers { get; set; }

    }
}