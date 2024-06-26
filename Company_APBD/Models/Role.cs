using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models;

public class Role
{
    [Key]
    [Column("ID")]
    public int RoleID { get; set; }

    [Column("Name")] 
    public string Name { get; set; }

    public List<Employee> Employees { get; set; } = new List<Employee>();
}