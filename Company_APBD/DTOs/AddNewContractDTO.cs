using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;

public class AddNewContractDTO
{
    
    public int CustomerId { get; set; }
    
    public int SoftwareId { get; set; }  
    
    public int DiscountId { get; set; }  

    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; } 
    
    public int SupportYears { get; set; } 
    

}