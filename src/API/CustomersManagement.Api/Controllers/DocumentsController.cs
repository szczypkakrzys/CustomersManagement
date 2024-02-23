using CustomersManagement.Application.Features.Documents.Commands.CreateDocument;
using CustomersManagement.Application.Features.Documents.Commands.DownloadDocument;
using CustomersManagement.Application.Features.Documents.Commands.FillDocument;
using CustomersManagement.Application.Features.Documents.Queries.GetAllDocumentsTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomersManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //todo !!!
    //
    //take a look at all DocuemtDtos and Queries

    [HttpGet]
    public Task<List<DocumentDto>> GetAllDocumentsTemplates()
    {
        var documents = _mediator.Send(new GetAllDocumentsTemplatesQuery());
        return documents;
    }

    [HttpGet("{id}")]
    public Task<DocumentDto> Get(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("download/{id}")]
    public async Task<IActionResult> Download(int id)
    {
        try
        {
            var response = await _mediator.Send(new DownloadDocumentCommand(id));
            //todo 
            //add contentType

            return File(response.Stream, response.ContentType, response.FileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return NotFound();
        }
    }

    [HttpGet("customer/{id}")]
    public Task<List<DocumentDto>> GetCustomerDocuments(int customerId)
    {
        throw new NotImplementedException();

    }

    [HttpPost("upload")]
    public async Task<ActionResult<List<UploadDocumentResult>>> UploadDocument(UploadDocumentCommand data)
    {
        //todo
        //for now it only uploads template 
        var result = await _mediator.Send(data);
        return Ok(result);
    }

    [HttpPost("set-form-rules")]
    public Task<IActionResult> SetDocumentFormFillRules()
    {
        throw new NotImplementedException();

    }

    [HttpPost("fill")]
    public async Task<IActionResult> FillDocumentForm(FillDocumentCommand data)
    {
        var response = await _mediator.Send(data);
        return NoContent();
    }

    //todo
    //add delete
    //add POST to update fill form rules
}
