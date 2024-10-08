﻿using AutoMapper;
using Blazored.LocalStorage;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Newsletter;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Services;

public class EmailService : BaseHttpService, IEmailService
{
    private readonly IMapper _mapper;

    public EmailService(
        IClient client,
        ILocalStorageService localStorageService,
        IMapper mapper) : base(client, localStorageService)
    {
        _mapper = mapper;
    }

    public async Task<Response<Guid>> SendEmail(EmailVM email)
    {
        try
        {
            await AddBearerToken();
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
