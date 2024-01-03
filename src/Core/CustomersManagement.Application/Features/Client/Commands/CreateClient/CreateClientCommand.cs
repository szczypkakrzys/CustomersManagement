using MediatR;

namespace CustomersManagement.Application.Features.Client.Commands.CreateClient;

public class CreateClientCommand : IRequest<int>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}
