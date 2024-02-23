using CustomersManagement.Application.Features.Documents.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CustomersManagement.Application.Features.Documents.Commands.CreateDocument;

public class UploadDocumentCommand : IRequest<List<UploadDocumentResult>>
{
    //todo - push change to enum
    public DocumentType Type { get; set; }
    //public string RemotePath = "path";
    //public string FileName { get; set; } = string.Empty;
    //public IEnumerable<IFormFile> Files { get; set; }
    public List<IFormFile> Files { get; set; }
}
