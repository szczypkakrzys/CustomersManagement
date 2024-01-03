using MediatR;

namespace CustomersManagement.Application.Features.Client.Queries.GetClientDetails;

public record GetClientDetailsQuery(int Id) : IRequest<ClientDetailsDto>;
