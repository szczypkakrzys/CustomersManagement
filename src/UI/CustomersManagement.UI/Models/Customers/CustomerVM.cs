using System.ComponentModel.DataAnnotations;

namespace CustomersManagement.UI.Models.Customers;

public class CustomerVM
{
    //todo
    //add here client site validation - because API calls all the time are expensive :D
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string EmailAddress { get; set; } = string.Empty;
}
