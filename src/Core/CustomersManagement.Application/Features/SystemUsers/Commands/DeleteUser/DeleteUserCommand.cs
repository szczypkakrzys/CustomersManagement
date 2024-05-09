using MediatR;

namespace CustomersManagement.Application.Features.SystemUsers.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public string Id { get; set; }
}
