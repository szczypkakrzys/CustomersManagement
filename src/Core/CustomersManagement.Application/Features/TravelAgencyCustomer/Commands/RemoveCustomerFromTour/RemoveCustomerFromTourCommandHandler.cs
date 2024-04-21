using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Commands.RemoveCustomerFromTour;

public class RemoveCustomerFromTourCommandHandler : IRequestHandler<RemoveCustomerFromTourCommand, Unit>
{
    private readonly ICustomersToursRelationsRepository _relationsRepository;

    public RemoveCustomerFromTourCommandHandler(ICustomersToursRelationsRepository relationsRepository)
    {
        _relationsRepository = relationsRepository;
    }

    public async Task<Unit> Handle(
        RemoveCustomerFromTourCommand request,
        CancellationToken cancellationToken)
    {
        var details = await _relationsRepository.GetCustomerTourDetails(request.CustomerId, request.TourId) ??
            throw new NotFoundException($"Relation with customerId: {request.CustomerId} and tourId:", request.TourId);

        await _relationsRepository.DeleteAsync(details);

        return Unit.Value;
    }
}
