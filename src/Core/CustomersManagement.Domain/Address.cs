using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain;

public class Address : BaseEntity
{
    public string City { get; set; }
    public string Street { get; set; }
    public int HouseNumber { get; set; }
    public string PostalCode { get; set; }
}