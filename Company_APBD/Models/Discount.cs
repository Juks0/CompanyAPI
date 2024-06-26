using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models
{
    public class Discount
    {
        [Column("ID")]
        public int DiscountID { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("DiscountType")]
        public string DiscountType { get; set; }

        [Required]
        [Range(0, 100)]
        [Column("Value")]
        public decimal Value { get; set; }

        [Required]
        [Column("StartDate")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column("EndDate")]
        public DateTime EndDate { get; set; }

        // public IEnumerable<Software_discount> SoftwareDiscounts { get; set; }

    }
}