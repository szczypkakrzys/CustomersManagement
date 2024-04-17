using CustomersManagement.Application.Features.Shared;

namespace CustomersManagement.Application.Features.Customer.Queries.GetCustomerDetails;

public class TravelAgencyCustomerDetailsDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public AddressDto Address { get; set; }
}
