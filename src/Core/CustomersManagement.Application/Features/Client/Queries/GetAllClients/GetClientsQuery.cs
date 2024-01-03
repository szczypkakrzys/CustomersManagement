using MediatR;

namespace CustomersManagement.Application.Features.Client.Queries.GetAllClients;

public record GetClientsQuery : IRequest<List<ClientDto>>;