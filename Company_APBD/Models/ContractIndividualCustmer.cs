using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models;

[Table("ContractCustomerIndividual")]
public class ContractIndividualCustomer
{
    [Key] [Column("ID")] 
    public int ContractID { get; set; }
    
    [Column("Price")] 
    public decimal Price { get; set; }

    [Column("isPaid")] 
    public decimal isPaid { get; set; }
    [Column("discountID")] 
    public int discountID { get; set; }
    [Column("TotalToPay")] 
    public decimal TotalToPay { get; set; }


    [Column("startDate")] 
    public DateTime startDate { get; set; }

    [Column("endDate")] 
    public DateTime endDate { get; set; }

    [Column("ContactLength")] 
    public int ContactLength { get; set; }

    [Column("isActive")]
    public bool isActive { get; set; }

    [ForeignKey("Software")]
    [Column("Fk_Software")]
    public int SoftwareID { get; set; }

    public Software Software { get; set; }

    [ForeignKey("IndvidualCustomer")] public int IndividualCustomerID { get; set; }
    public IndividualCustomer Individualcustomer { get; set; }

    public ICollection<ContractIndividualCustomer> ContractIndividualCustomers { get; set; }
}