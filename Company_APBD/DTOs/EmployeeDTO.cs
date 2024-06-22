using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;

public class EmployeeDTO
{
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "Login is required")]
    public string Login { get; set; }

    public string Role { get; set; }
}