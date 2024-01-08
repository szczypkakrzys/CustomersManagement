﻿using AutoMapper;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Documents;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Services;

public class DocumentService : BaseHttpService, IDocumentService
{
    private readonly IMapper _mapper;

    public DocumentService(
        IClient client,
        IMapper mapper) : base(client)
    {
        _mapper = mapper;
    }

    public async Task<List<DocumentVM>> GetAllDocuments()
    {
        var documents = await _client.DocumentsAllAsync();
        return _mapper.Map<List<DocumentVM>>(documents);
    }

    public async Task<Response<Guid>> GenerateDocument(string fileName, int customerId)
    {
        try
        {
            //FillDocumentFormCommand
            //todo
            //shall I create document here of just pass both values somehow? - compare with customer's commands
            var fillDocumentCommand = new FillDocumentCommand
            {
                UserId = customerId,
                FileName = fileName
            };
            //var updateCustomerCommand = _mapper.Map<UpdateClientCommand>(customer);
            //await _client.ClientsPUTAsync(id.ToString(), updateCustomerCommand);
            await _client.DocumentsAsync(fillDocumentCommand);
            return new Response<Guid>() { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }

        //throw new NotImplementedException();
    }
}
