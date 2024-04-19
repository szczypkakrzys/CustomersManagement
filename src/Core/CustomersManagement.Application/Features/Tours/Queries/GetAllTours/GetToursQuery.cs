using MediatR;

namespace CustomersManagement.Application.Features.Tours.Queries.GetAllTours;

public record GetToursQuery : IRequest<IEnumerable<TourDto>>;
