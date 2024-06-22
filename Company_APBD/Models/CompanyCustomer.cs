﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_APBD.Models;

[Table("company_customers")]

public class CompanyCustomer : Customer
{
    [Required]
    public string CompanyName { get; set; }

    [Required]
    [StringLength(10)]
    public string KRS { get; set; }
}