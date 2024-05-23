using FluentValidation;

namespace CustomersManagement.Application.Features.Emails.Commands.CreateEmailTemplate;

public class CreateEmailTemplateCommandValidator : AbstractValidator<CreateEmailTemplateCommand>
{
    public CreateEmailTemplateCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
                .WithMessage("{PropertyName} is required");

        RuleFor(p => p.Content)
           .NotEmpty()
               .WithMessage("{PropertyName} is required");

        RuleFor(p => p.Type)
           .NotEmpty()
               .WithMessage("{PropertyName} is required")
            .IsInEnum();
    }
}
