using System.ComponentModel.DataAnnotations;

namespace CustomersManagement.Application.Models.Identity;

public class RegistrationRequest
{
    //TODO
    //improve below data validation - can use fluent validation

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
