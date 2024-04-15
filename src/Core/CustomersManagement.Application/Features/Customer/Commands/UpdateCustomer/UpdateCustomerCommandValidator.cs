using CustomersManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CustomersManagement.Application.Features.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;

    public UpdateCustomerCommandValidator(ITravelAgencyCustomerRepository customerRepository)
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

        RuleFor(q => q)
            .MustAsync(CustomerDataUnique)
                .WithMessage("Given customer already exists");

        _customerRepository = customerRepository;
    }

    private async Task<bool> CustomerMustExist(
        int id,
        CancellationToken token)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return customer != null;
    }

    private Task<bool> CustomerDataUnique(
        UpdateCustomerCommand command,
        CancellationToken token)
    {
        return _customerRepository.IsCustomerUnique(
            command.FirstName,
            command.LastName,
            command.EmailAddress);
    }


}