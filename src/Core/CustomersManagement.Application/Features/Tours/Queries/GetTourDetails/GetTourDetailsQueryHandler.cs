using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.TravelAgency;
using MediatR;

namespace CustomersManagement.Application.Features.Tours.Queries.GetTourDetails;

public class GetTourDetailsQueryHandler : IRequestHandler<GetTourDetailsQuery, TourDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ITourRepository _tourRepository;

    public GetTourDetailsQueryHandler(
        IMapper mapper,
        ITourRepository tourRepository)
    {
        _mapper = mapper;
        _tourRepository = tourRepository;
    }

    public async Task<TourDetailsDto> Handle(
        GetTourDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var tourDetails = await _tourRepository.GetByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(Tour), request.Id);

        var data = _mapper.Map<TourDetailsDto>(tourDetails);

        return data;
    }
}
