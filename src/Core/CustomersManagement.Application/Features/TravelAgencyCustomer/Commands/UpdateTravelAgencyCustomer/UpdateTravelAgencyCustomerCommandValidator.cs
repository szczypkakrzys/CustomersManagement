using CustomersManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CustomersManagement.Application.Features.Customer.Commands.UpdateCustomer;

public class UpdateTravelAgencyCustomerCommandValidator : AbstractValidator<UpdateTravelAgencyCustomerCommand>
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;

    public UpdateTravelAgencyCustomerCommandValidator(ITravelAgencyCustomerRepository customerRepository)
    {
        RuleFor(p => p.Id)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .MustAsync(CustomerMustExist)
                .WithMessage("Couldn't find customer with Id = {PropertyValue}");

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

    private async Task<bool> CustomerMustExist(
        int id,
        CancellationToken token)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return customer != null;
    }
}