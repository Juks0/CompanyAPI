namespace Company_APBD.Models;

public class DeletedCustomers : Customer
{
    public int CustomerId { get; set; }
    public string CustomerType { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CompanyName { get; set; }
    public string KRS { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PESEL { get; set; }
}