using CustomersManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.CreateTravelAgencyCustomer;

public class CreateTravelAgencyCustomerCommandValidator : AbstractValidator<CreateTravelAgencyCustomerCommand>
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;

    public CreateTravelAgencyCustomerCommandValidator(ITravelAgencyCustomerRepository customerRepository)
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

        RuleFor(p => p.DateOfBirth)
           .NotEmpty()
               .WithMessage("{PropertyName} is required");

        RuleFor(p => p.PhoneNumber)
            .NotEmpty()
                .WithMessage("{PropertyName} is required");

        RuleFor(p => p.Address)
            .NotEmpty()
                .WithMessage("{PropertyName} is required");

        _customerRepository = customerRepository;
    }

    private Task<bool> CustomerDataUnique(
        CreateTravelAgencyCustomerCommand command,
        CancellationToken token)
    {
        return _customerRepository.IsCustomerUnique(
            command.FirstName,
            command.LastName,
            command.EmailAddress);
    }
}
