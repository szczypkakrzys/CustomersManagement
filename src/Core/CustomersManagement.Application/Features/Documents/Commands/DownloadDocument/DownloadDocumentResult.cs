namespace CustomersManagement.Application.Features.Documents.Commands.DownloadDocument;

public class DownloadDocumentResult
{
    public MemoryStream Stream { get; set; }
    public string ContentType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
}
