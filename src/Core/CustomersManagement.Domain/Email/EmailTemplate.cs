using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain.Email;

public class EmailTemplate : BaseEntity
{
    public string Name { get; set; }
    public string Content { get; set; }
    public EmailType Type { get; set; }
}
