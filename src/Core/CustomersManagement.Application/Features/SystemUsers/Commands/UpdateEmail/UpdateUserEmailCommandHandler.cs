using CustomersManagement.Application.Contracts.Identity;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.SystemUsers.Commands.UpdateEmail;

public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand, Unit>
{
    private readonly IUserService _userService;

    public UpdateUserEmailCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Unit> Handle(
        UpdateUserEmailCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new UpdateUserEmailCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid User", validationResult);

        await _userService.ChangeEmail(request.Id, request.NewEmail);

        return Unit.Value;
    }
}
