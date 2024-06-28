using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models;

public class Role
{
    [Key]
    [Column("ID")]
    [Required]
    public int RoleID { get; set; }

    [Column("Name")] 
    [Required]
    public string Name { get; set; }

    public List<Employee> Employees { get; set; } = new List<Employee>();
}