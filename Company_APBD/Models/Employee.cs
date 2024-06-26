using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models
{
    public class Employee
    {
        [Key] [Column("ID")] public int EmployeeId { get; set; }

        [Required] 
        [Column("Login")] 
        public string Login { get; set; }

        [Required] 
        [Column("Password")] 
        public string Password { get; set; }

        [Required]
        [ForeignKey("RoleID")]
        [Column("FK_RoleID")]
        public int RoleID { get; set; }

        public Role Role { get; set; }
    }
}