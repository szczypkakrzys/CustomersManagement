using CustomersManagement.Application.Contracts.Logging;
using MailKit.Net.Smtp;
using MediatR;
using MimeKit;


namespace CustomersManagement.Application.Features.Newsletter.SendEmail;

public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, Unit>
{
    private readonly IMediator _mediator;
    private readonly IAppLogger<SendEmailCommandHandler> _logger;

    public SendEmailCommandHandler(
        IMediator mediator,
        IAppLogger<SendEmailCommandHandler> logger)
    {

        _mediator = mediator;
        _logger = logger;
    }

    public async Task<Unit> Handle(
        SendEmailCommand request,
        CancellationToken cancellationToken)
    {
        var emailAddress = "chance.boehm1@ethereal.email";
        var password = "gRSVdDM9QSBpckHXyv";


        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(emailAddress));
        email.To.Add(MailboxAddress.Parse(emailAddress));
        email.Subject = "Test Email Subject";

        //test body
        //var builder = new BodyBuilder();
        //builder.HtmlBody = request.MessageContent;
        /*
        "<p>This is a message with an embedded image:</p>" +
        "<p><img src='cid:image'></p>"; // 'cid' is the Content-ID referencing the embedded image

        var image = builder.LinkedResources.Add("C:\\Users\\Krzysiek\\Downloads\\alpakaImage.jpg"); // Replace with your image path
    image.ContentId = "image";
        */

        // Load and embed the image
        //builder.LinkedResources.Add("image", "C:\\Users\\Krzysiek\\Downloads\\Cat03.jpg"); // Replace with your image path

        // Set the HTML body with the embedded image as the message body
        //email.Body = builder.ToMessageBody();
        //end of test body

        //uncomment when ready
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.MessageContent };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
        smtp.Authenticate(emailAddress, password);
        smtp.Send(email);
        smtp.Disconnect(true);

        return Unit.Value;
    }
}
