using MediatR;

namespace CustomersManagement.Application.Features.SystemUsers.Commands.UpdateEmail;

public class UpdateUserEmailCommand : IRequest<Unit>
{
    public string Id { get; set; }
    public string NewEmail { get; set; }
}
