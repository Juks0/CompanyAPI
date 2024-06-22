﻿using System.ComponentModel.DataAnnotations;

namespace Company_APBD.Models;

public class Employee
{
    public int EmployeeId { get; set; }

    [Required]
    public string Login { get; set; }

    public string Role { get; set; }
}