using System.ComponentModel.DataAnnotations;

namespace CustomersManagement.UI.Models.Newsletter;

public class EmailVM
{
    [Required]
    public string MessageContent { get; set; } = string.Empty;
}
