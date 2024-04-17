using CustomersManagement.Application.Features.TravelAgencyCustomer.Commands.CreateTravelAgencyCustomer;
using MediatR;

namespace CustomersManagement.Application.Features.Customer.Commands.CreateCustomer;

public class CreateTravelAgencyCustomerCommand : IRequest<int>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public CreateAddressDto Address { get; set; }
}
