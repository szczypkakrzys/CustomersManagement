using MediatR;

namespace CustomersManagement.Application.Features.Customer.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<int>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}
