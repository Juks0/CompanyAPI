﻿using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;
public class SoftwareDTO
{
    public int SoftwareId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    public string Description { get; set; }
    public string CurrentVersion { get; set; }
    public string Category { get; set; }
}