using MediatR;

namespace CustomersManagement.Application.Features.Emails.Commands.SendEmail;

public class SendEmailCommand : IRequest<Unit>
{
    public IEnumerable<string> ReceiversAddresses { get; set; }
    public string Subject { get; set; }
    public string EmailContent { get; set; }
}
