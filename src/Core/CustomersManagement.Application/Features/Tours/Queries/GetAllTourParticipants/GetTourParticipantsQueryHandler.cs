using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.TravelAgency;
using MediatR;

namespace CustomersManagement.Application.Features.Tours.Queries.GetAllTourParticipants;

public class GetTourParticipantsQueryHandler : IRequestHandler<GetTourParticipantsQuery, IEnumerable<TourParticipantDto>>
{
    private readonly ITourRepository _tourRepository;
    private readonly IMapper _mapper;

    public GetTourParticipantsQueryHandler(
        ITourRepository tourRepository,
        IMapper mapper)
    {
        _tourRepository = tourRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TourParticipantDto>> Handle(
        GetTourParticipantsQuery request,
        CancellationToken cancellationToken)
    {
        var tour = await _tourRepository.GetByIdWithParticipants(request.Id) ??
               throw new NotFoundException(nameof(Tour), request.Id);

        var result = _mapper.Map<IEnumerable<TourParticipantDto>>(tour.Participants);

        return result;
    }
}
