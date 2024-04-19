using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.TravelAgency;
using MediatR;

namespace CustomersManagement.Application.Features.Tours.Commands.UpdateTour;

public class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ITourRepository _tourRepository;

    public UpdateTourCommandHandler(
        IMapper mapper,
        ITourRepository tourRepository)
    {
        _mapper = mapper;
        _tourRepository = tourRepository;
    }

    public async Task<Unit> Handle(
        UpdateTourCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new UpdateTourCommandValidator(_tourRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid Tour data", validationResult);

        var tourToUpdate = _mapper.Map<Tour>(request);

        await _tourRepository.UpdateAsync(tourToUpdate);

        return Unit.Value;
    }
}
