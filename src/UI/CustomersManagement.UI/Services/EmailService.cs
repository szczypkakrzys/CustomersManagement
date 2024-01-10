using AutoMapper;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Newsletter;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Services;

public class EmailService : BaseHttpService, IEmailService
{
    private readonly IMapper _mapper;

    public EmailService(
        IClient client,
        IMapper mapper) : base(client)
    {
        _mapper = mapper;
    }

    public async Task<Response<Guid>> SendEmail(EmailVM email)
    {
        try
        {
            var sendEmailCommand = _mapper.Map<SendEmailCommand>(email);
            await _client.EmailAsync(sendEmailCommand);
            return new Response<Guid>() { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
