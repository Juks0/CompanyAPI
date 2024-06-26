using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models;

public class Software_discount
{
    [Key]
    [Column("ID")]
    public int ID { get; set; }
    
    [ForeignKey("SoftwareID")]
    [Column("FK_SoftwareID")]
    public int SoftwareID { get; set; }
    public Software Software { get; set; }
    
    [ForeignKey("DiscountID")]
    [Column("FK_DiscountID")]
    public int DiscountID { get; set; }
    public Discount Discount { get; set; }
}