using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain;

public class Document : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public string RemotePath { get; set; } = string.Empty;
    public int? ClienId { get; set; }
    public Client? Client { get; set; }
}
