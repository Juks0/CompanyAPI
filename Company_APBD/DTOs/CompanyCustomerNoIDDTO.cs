﻿using System.ComponentModel.DataAnnotations;

namespace Company_APBD.DTOs;

public  class CompanyCustomerNoIDDTO
{
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CompanyName { get; set; }
    public string KRS { get; set; }
}