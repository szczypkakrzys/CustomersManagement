using CustomersManagement.Application.Features.Shared;
using MediatR;

namespace CustomersManagement.Application.Features.Customer.Commands.UpdateCustomer;

public class UpdateTravelAgencyCustomerCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public AddressDto Address { get; set; }
}
