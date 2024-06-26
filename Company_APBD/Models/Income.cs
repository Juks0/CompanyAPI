using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models;

public class Income
{
    [Key]
    [Column("ID")]
    public int IncomeID { get; set; }
    
    [ForeignKey("ContractIndividualCustomerID")]
    [Column("ContractIndividualCustomerID")]
    public int? ContractIndividualCustomerID { get; set; }
    public int ContractIndividualCustomer { get; set; }
    
    [ForeignKey("ContractCompanyCustomerID")]
    [Column("ContractCompanyCustomerID")]
    public int? ContractCompanyCustomerID { get; set; }
    public int ContractCompanyCustomer { get; set; }
    
    [Column("Ammount")]
    public decimal Ammount { get; set; }
    
    [Column("DateOfIncome")]
    public DateTime DateOfIncome { get; set; }
}