using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models
{
    public class Software
    {
        [Key]
        [Column("ID")]
        public int SoftwareID { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Price")]
        public decimal Price { get; set; }

        [Required]
        [Column("Description")]
        public string Description { get; set; }

        [Required]
        [Column("CurrentVersion")]
        public string CurrentVersion { get; set; }

        [Required]
        [Column("Category")]
        public string Category { get; set; }

        // public IEnumerable<ContractIndividualCustomer>? ContractIndividualCustomers { get; set; }
        // public IEnumerable<ContractCompanyCustmer>? ContractCompanyCustmers { get; set; }
        // public IEnumerable<Software_discount>? SoftwareDiscounts { get; set; }
    }
}