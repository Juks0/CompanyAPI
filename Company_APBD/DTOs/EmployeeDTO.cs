using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;

public class EmployeeDTO
{
    public int EmployeeId { get; set; }

    public string Login { get; set; }

    public string Role { get; set; }
}