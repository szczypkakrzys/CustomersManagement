using CustomersManagement.Application.Contracts.Identity;
using MediatR;

namespace CustomersManagement.Application.Features.SystemUsers.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Unit> Handle(
        DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        await _userService.DeleteEmployee(request.Id);

        return Unit.Value;
    }
}
