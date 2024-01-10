using MediatR;

namespace CustomersManagement.Application.Features.Newsletter.SendEmail;

public class SendEmailCommand : IRequest<Unit>
{
    public string MessageContent { get; set; } = string.Empty;
}
