using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.TravelAgency;
using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.AssignCustomerToTour;

public class AssignCustomerCommandHandler : IRequestHandler<AssignCustomerCommand, Unit>
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;
    private readonly ITourRepository _tourRepository;
    private readonly ICustomersToursRelationsRepository _relationsRepository;

    public AssignCustomerCommandHandler(
        ITravelAgencyCustomerRepository customerRepository,
        ITourRepository tourRepository,
        ICustomersToursRelationsRepository relationsRepository)
    {
        _customerRepository = customerRepository;
        _tourRepository = tourRepository;
        _relationsRepository = relationsRepository;
    }

    public async Task<Unit> Handle(
    AssignCustomerCommand request,
    CancellationToken cancellationToken)
    {
        var validator = new AssignCustomerCommandValidator(
                                _relationsRepository,
                                _customerRepository,
                                _tourRepository);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid Relation", validationResult);

        var tourDetails = await _tourRepository.GetByIdAsync(request.TourId);

        var relation = new CustomersToursRelations
        {
            CustomerId = request.CustomerId,
            TourId = request.TourId,
            EnrollmentDate = DateOnly.FromDateTime(DateTime.Now),
            Status = "unknown",
            AdvancedPaymentDate = null,
            EntireAmountPaymentDate = null,
            AdvancedPaymentLeftToPay = tourDetails.AdvancePaymentCost,
            EntireCostLeftToPay = tourDetails.EntireCost
        };

        await _relationsRepository.CreateAsync(relation);

        return Unit.Value;
    }
}
