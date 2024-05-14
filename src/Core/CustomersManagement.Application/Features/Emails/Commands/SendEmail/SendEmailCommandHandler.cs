using CustomersManagement.Application.Contracts.Email;
using CustomersManagement.Application.Contracts.Logging;
using MediatR;

namespace CustomersManagement.Application.Features.Emails.Commands.SendEmail;

public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, Unit>
{
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger<SendEmailCommandHandler> _logger;

    public SendEmailCommandHandler(
        IEmailSender emailSender,
        IAppLogger<SendEmailCommandHandler> logger)
    {
        _emailSender = emailSender;
        _logger = logger;
    }

    public async Task<Unit> Handle(
        SendEmailCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            await _emailSender.SendEmailAsync(request.ReceiversAddresses, request.Subject, request.EmailContent);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while sending email");
            throw;
        }
    }
}
