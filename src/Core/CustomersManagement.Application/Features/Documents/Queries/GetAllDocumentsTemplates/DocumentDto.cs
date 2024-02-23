namespace CustomersManagement.Application.Features.Documents.Queries.GetAllDocumentsTemplates;

public class DocumentDto
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string RemotePath { get; set; } = string.Empty;
}
