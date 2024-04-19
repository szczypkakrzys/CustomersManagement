using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.TravelAgency;
using MediatR;

namespace CustomersManagement.Application.Features.Tours.Commands.CreateTour;

public class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ITourRepository _tourRepository;

    public CreateTourCommandHandler(
        IMapper mapper,
        ITourRepository tourRepository)
    {
        _mapper = mapper;
        _tourRepository = tourRepository;
    }

    public async Task<int> Handle(
        CreateTourCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateTourCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid Tour", validationResult);

        var tourToCreate = _mapper.Map<Tour>(request);

        await _tourRepository.CreateAsync(tourToCreate);

        return tourToCreate.Id;
    }
}
