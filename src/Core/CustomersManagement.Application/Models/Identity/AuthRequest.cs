﻿namespace CustomersManagement.Application.Models.Identity;

public class AuthRequest
{
    public string EmailAddress { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
