using MediatR;

namespace CustomersManagement.Application.Features.Tours.Queries.GetTourDetails;

public record GetTourDetailsQuery(int Id) : IRequest<TourDetailsDto>;
