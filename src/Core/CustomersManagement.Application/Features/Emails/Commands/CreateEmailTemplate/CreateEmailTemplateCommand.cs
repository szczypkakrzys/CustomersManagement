using CustomersManagement.Domain.Email;
using MediatR;

namespace CustomersManagement.Application.Features.Emails.Commands.CreateEmailTemplate;
public class CreateEmailTemplateCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Content { get; set; }
    public EmailType Type { get; set; }
}
