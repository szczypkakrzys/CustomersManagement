namespace CustomersManagement.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeLastModified { get; set; }
}