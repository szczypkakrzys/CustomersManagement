using MediatR;

namespace CustomersManagement.Application.Features.Tours.Queries.GetAllTourParticipants;

public record GetTourParticipantsQuery(int Id) : IRequest<IEnumerable<TourParticipantDto>>;