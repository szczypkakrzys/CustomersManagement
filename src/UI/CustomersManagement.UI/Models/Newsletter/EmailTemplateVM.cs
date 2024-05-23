using CustomersManagement.UI.Services.Base;
using System.ComponentModel.DataAnnotations;

namespace CustomersManagement.UI.Models.Newsletter;

public class EmailTemplateVM
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public EmailType Type { get; set; }
}
