using FluentValidation;

namespace CustomersManagement.Application.Features.SystemUsers.Commands.UpdateEmail;

public class UpdateUserEmailCommandValidator : AbstractValidator<UpdateUserEmailCommand>
{
    public UpdateUserEmailCommandValidator()
    {
        RuleFor(p => p.Id)
          .NotEmpty()
              .WithMessage("{PropertyName} is required");

        RuleFor(p => p.NewEmail)
          .NotEmpty()
              .WithMessage("{PropertyName} is required")
          .EmailAddress()
              .WithMessage("{PropertyValue} is not a valid Email");
    }
}
