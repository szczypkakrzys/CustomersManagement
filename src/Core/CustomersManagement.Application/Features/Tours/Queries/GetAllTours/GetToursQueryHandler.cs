using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using MediatR;

namespace CustomersManagement.Application.Features.Tours.Queries.GetAllTours;

public class GetToursQueryHandler : IRequestHandler<GetToursQuery, IEnumerable<TourDto>>
{
    private readonly IMapper _mapper;
    private readonly ITourRepository _tourRepository;

    public GetToursQueryHandler(
        IMapper mapper,
        ITourRepository tourRepository)
    {
        _mapper = mapper;
        _tourRepository = tourRepository;
    }

    public async Task<IEnumerable<TourDto>> Handle(
        GetToursQuery request,
        CancellationToken cancellationToken)
    {
        var tour = await _tourRepository.GetAsync();

        var data = _mapper.Map<IEnumerable<TourDto>>(tour);

        return data;
    }
}
