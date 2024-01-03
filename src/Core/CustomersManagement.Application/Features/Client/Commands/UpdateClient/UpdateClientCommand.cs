using MediatR;

namespace CustomersManagement.Application.Features.Client.Commands.UpdateClient;

public class UpdateClientCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}
