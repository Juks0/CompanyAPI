using System.ComponentModel.DataAnnotations;

namespace Company_APBD.Models;

public class Software
{
    public int SoftwareId { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string CurrentVersion { get; set; }
    [Required]
    public string Category { get; set; }
}