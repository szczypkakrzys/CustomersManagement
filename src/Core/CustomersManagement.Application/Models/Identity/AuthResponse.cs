﻿namespace CustomersManagement.Application.Models.Identity;

public class AuthResponse
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string EmailAddress { get; set; }
    public string Token { get; set; }
}
