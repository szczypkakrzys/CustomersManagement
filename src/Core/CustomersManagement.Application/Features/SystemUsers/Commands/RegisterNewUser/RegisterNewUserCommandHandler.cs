using CustomersManagement.Application.Contracts.Identity;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.SystemUsers.Commands.RegisterNewUser;

public class RegisterNewUserCommandHandler : IRequestHandler<RegisterNewUserCommand, string>
{
    private readonly IUserService _userService;

    public RegisterNewUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<string> Handle(
        RegisterNewUserCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new RegisterNewUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid User", validationResult);

        var user = await _userService.Register(request);

        return user.UserId;
    }
}