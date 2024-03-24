using System.ComponentModel.DataAnnotations;

namespace CustomersManagement.Application.Models.Identity;

public class RegistrationRequest
{
    //TODO
    //update whole auth to .NET 8 solution

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
