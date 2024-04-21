using CustomersManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.AssignCustomerToTour;

public class AssignCustomerCommandValidator : AbstractValidator<AssignCustomerCommand>
{
    private readonly ICustomersToursRelationsRepository _relationsRepository;
    private readonly ITravelAgencyCustomerRepository _customerRepository;
    private readonly ITourRepository _tourRepository;

    public AssignCustomerCommandValidator(
        ICustomersToursRelationsRepository relationsRepository,
        ITravelAgencyCustomerRepository customerRepository,
        ITourRepository tourRepository)
    {
        RuleFor(q => q)
            .MustAsync(CustomerIsNotAlreadyAssingedToGivenTour)
                .WithMessage("Given customer is already assigned to this tour");

        RuleFor(p => p.CustomerId)
            .NotEmpty()
               .WithMessage("{PropertyName} is required")
            .MustAsync(CustomerMustExist)
                .WithMessage("Couldn't find customer with Id = {PropertyValue}");


        RuleFor(p => p.TourId)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .MustAsync(TourMustExist)
                .WithMessage("Couldn't find tour with Id = {PropertyValue}");

        _relationsRepository = relationsRepository;
        _customerRepository = customerRepository;
        _tourRepository = tourRepository;
    }

    private Task<bool> CustomerIsNotAlreadyAssingedToGivenTour(
        AssignCustomerCommand command,
        CancellationToken token)
    {
        return _relationsRepository.IsNotAlreadyAssigned(
            command.CustomerId,
            command.TourId);
    }

    private async Task<bool> CustomerMustExist(
        int id,
        CancellationToken token)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return customer != null;
    }

    private async Task<bool> TourMustExist(
        int id,
        CancellationToken token)
    {
        var tour = await _tourRepository.GetByIdAsync(id);
        return tour != null;
    }
}
