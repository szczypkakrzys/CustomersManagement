namespace CustomersManagement.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime TimeCreatedInUtc { get; set; }
    public DateTime TimeLastModifiedInUtc { get; set; }
}