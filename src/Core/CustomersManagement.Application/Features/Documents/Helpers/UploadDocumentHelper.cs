using CustomersManagement.Application.Features.Documents.Enums;

namespace CustomersManagement.Application.Features.Documents.Helpers;

//todo
//replace that class with service or something :)
public class UploadDocumentHelper
{
    public string FileName { get; set; } = string.Empty;
    public DocumentType Type { get; set; }
    public string RemotePath { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;

}
