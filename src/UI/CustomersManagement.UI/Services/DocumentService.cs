using AutoMapper;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Documents;
using CustomersManagement.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CustomersManagement.UI.Services;

public class DocumentService : BaseHttpService, IDocumentService
{
    private readonly IMapper _mapper;
    private readonly HttpClient _httpClient;

    //todo
    //do some cleaning there
    public DocumentService(
        IClient client,
        IMapper mapper,
        HttpClient httpClient) : base(client)
    {
        _mapper = mapper;
        _httpClient = httpClient;
    }
    [Inject]
    public IJSRuntime _js { get; set; }
    public Task<Response<Guid>> GenerateDocument(string fileName, int customerId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<DocumentVM>> GetAllDocuments()
    {
        var documents = await _client.DocumentsAllAsync();
        return _mapper.Map<List<DocumentVM>>(documents);
    }

    public async Task<Response<Guid>> UploadDocument(IEnumerable<FileParameter> documents, DocumentType type)
    {
        var response = await _client.UploadAsync(type, documents);
        return new Response<Guid>() { IsSuccess = true };
    }

    public async Task<Response<Guid>> DownloadDocument(int id, string fileName)
    {
        //throw new NotImplementedException();
        //below line does not work thanks to nswag studio
        //var response = await _client.DownloadAsync(id);
        var response = await _httpClient.GetAsync($"https://localhost:7193/api/Documents/download/{id}");
        var fileStream = response.Content.ReadAsStream();
        using var streamRef = new DotNetStreamReference(stream: fileStream);
        await _js.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        return new Response<Guid>() { IsSuccess = true };
    }

    //public async Task<Response<Guid>> GenerateDocument(string fileName, int customerId)
    //{
    //    try
    //    {
    //        //FillDocumentFormCommand
    //        //todo
    //        //shall I create document here of just pass both values somehow? - compare with customer's commands
    //        var fillDocumentCommand = new FillDocumentCommand
    //        {
    //            UserId = customerId,
    //            FileName = fileName
    //        };
    //        //var updateCustomerCommand = _mapper.Map<UpdateClientCommand>(customer);
    //        //await _client.ClientsPUTAsync(id.ToString(), updateCustomerCommand);
    //        await _client.DocumentsAsync(fillDocumentCommand);
    //        return new Response<Guid>() { IsSuccess = true };
    //    }
    //    catch (ApiException ex)
    //    {
    //        return ConvertApiExceptions<Guid>(ex);
    //    }

    //    //throw new NotImplementedException();
    //}
}
