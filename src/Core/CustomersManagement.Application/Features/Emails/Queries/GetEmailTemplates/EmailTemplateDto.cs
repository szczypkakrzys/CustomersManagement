using CustomersManagement.Domain.Email;

namespace CustomersManagement.Application.Features.Emails.Queries.GetEmailTemplates;

public class EmailTemplateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public EmailType Type { get; set; }
}
