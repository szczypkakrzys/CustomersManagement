using CustomersManagement.Application.Contracts.Email;
using CustomersManagement.Application.Models.Email;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CustomersManagement.Infrastructure.Email;

public class EmailSender : IEmailSender
{
    public EmailSettings _emailSettings { get; }

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendEmailAsync(IEnumerable<string> receiversList, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));

        foreach (var receiver in receiversList)
        {
            message.Bcc.Add(MailboxAddress.Parse(receiver));
        }
        message.Subject = subject;

        message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

        using var client = new SmtpClient();

        await client.ConnectAsync(_emailSettings.SmtpServer,
                       _emailSettings.Port,
                       MailKit.Security.SecureSocketOptions.SslOnConnect);
        await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
