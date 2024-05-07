using System.ComponentModel.DataAnnotations;

namespace CustomersManagement.UI.Models.Newsletter;

public class EmailVM
{
    [Required]
    public List<string> ReceiversAddresses { get; set; }

    [Required]
    public string Subject { get; set; }

    [Required]
    public string EmailContent { get; set; }
}
