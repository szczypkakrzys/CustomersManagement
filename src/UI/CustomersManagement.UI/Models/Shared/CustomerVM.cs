using System.ComponentModel.DataAnnotations;

namespace CustomersManagement.UI.Models.Shared;

public class CustomerVM
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Imię jest wymagane")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nazwisko jest wymagane")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Adres e-mail jest wymagany")]
    [EmailAddress(ErrorMessage = "Podany adres e-mail nie jest w poprawnym formacie")]
    public string EmailAddress { get; set; } = string.Empty;
}
