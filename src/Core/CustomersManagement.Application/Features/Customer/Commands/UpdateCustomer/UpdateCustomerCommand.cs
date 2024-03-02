using MediatR;

namespace CustomersManagement.Application.Features.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}
