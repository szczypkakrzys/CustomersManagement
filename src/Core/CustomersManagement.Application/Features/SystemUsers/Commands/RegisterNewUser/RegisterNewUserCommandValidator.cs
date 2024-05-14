using FluentValidation;

namespace CustomersManagement.Application.Features.SystemUsers.Commands.RegisterNewUser;

public class RegisterNewUserCommandValidator : AbstractValidator<RegisterNewUserCommand>
{
    public RegisterNewUserCommandValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty()
                .WithMessage("{PropertyName} is required");

        RuleFor(p => p.LastName)
           .NotEmpty()
               .WithMessage("{PropertyName} is required");

        RuleFor(p => p.EmailAddress)
           .NotEmpty()
               .WithMessage("{PropertyName} is required")
           .EmailAddress()
               .WithMessage("{PropertyValue} is not a valid Email");

        RuleFor(p => p.Password)
             .NotEmpty()
               .WithMessage("{PropertyName} is required");

        RuleFor(p => p.Role)
            .NotEmpty()
              .WithMessage("{PropertyName} is required");
    }
}
