using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.TravelAgency;
using MediatR;

namespace CustomersManagement.Application.Features.Tours.Commands.DeleteTour;

public class DeleteTourCommandHandler : IRequestHandler<DeleteTourCommand, Unit>
{
    private readonly ITourRepository _tourRepository;

    public DeleteTourCommandHandler(ITourRepository tourRepository) =>
        _tourRepository = tourRepository;

    public async Task<Unit> Handle(
        DeleteTourCommand request,
        CancellationToken cancellationToken)
    {
        var tourToDelete = await _tourRepository.GetByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(Tour), request.Id);

        await _tourRepository.DeleteAsync(tourToDelete);

        return Unit.Value;
    }
}
