using System.ComponentModel.DataAnnotations;

namespace CustomersManagement.Application.Models.Identity;

public class RegistrationRequest
{
    //TODO
    //update whole auth to .NET 8 solution

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;

    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
