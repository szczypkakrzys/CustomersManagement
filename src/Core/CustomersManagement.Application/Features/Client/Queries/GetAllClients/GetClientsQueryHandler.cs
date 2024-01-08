using AutoMapper;
using CustomersManagement.Application.Contracts.Logging;
using CustomersManagement.Application.Contracts.Persistence;
using MediatR;

namespace CustomersManagement.Application.Features.Client.Queries.GetAllClients;

public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientDto>>
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetClientsQueryHandler> _logger;

    public GetClientsQueryHandler(
        IMapper mapper,
        IClientRepository clientRepository,
        IAppLogger<GetClientsQueryHandler> logger)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
        _logger = logger;
    }

    public async Task<List<ClientDto>> Handle(
        GetClientsQuery request,
        CancellationToken cancellationToken)
    {
        var clients = await _clientRepository.GetAsync();

        var data = _mapper.Map<List<ClientDto>>(clients);

        _logger.LogInformation("All clients were retrieved successfullly");
        return data;
    }
}
