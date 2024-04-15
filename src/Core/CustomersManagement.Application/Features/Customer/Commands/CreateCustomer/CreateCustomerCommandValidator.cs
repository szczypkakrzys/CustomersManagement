using CustomersManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CustomersManagement.Application.Features.Customer.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;

    public CreateCustomerCommandValidator(ITravelAgencyCustomerRepository customerRepository)
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

        RuleFor(q => q)
            .MustAsync(CustomerDataUnique)
                .WithMessage("Given customer already exists");

        _customerRepository = customerRepository;
    }

    private Task<bool> CustomerDataUnique(
        CreateCustomerCommand command,
        CancellationToken token)
    {
        return _customerRepository.IsCustomerUnique(
            command.FirstName,
            command.LastName,
            command.EmailAddress);
    }
}
