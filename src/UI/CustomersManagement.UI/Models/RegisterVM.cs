using System.ComponentModel.DataAnnotations;

namespace CustomersManagement.UI.Models;

public class RegisterVM
{
    [Required(ErrorMessage = "Imię jest wymagane")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nazwisko jest wymagane")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Adres e-mail jest wymagany")]
    [EmailAddress(ErrorMessage = "Podany adres e-mail nie jest w poprawnym formacie")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Hasło jest wymagane")]
    public string Password { get; set; } = string.Empty;
}
