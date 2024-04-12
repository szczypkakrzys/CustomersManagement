using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain;

public class Address : BaseEntity
{
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int HouseNumber { get; set; }
    public string PostalCode { get; set; } = string.Empty;
}