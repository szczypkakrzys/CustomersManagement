using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.Client.Queries.GetClientDetails;

public class GetClientDetailsQueryHandler : IRequestHandler<GetClientDetailsQuery, ClientDetailsDto>
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    public GetClientDetailsQueryHandler(
        IClientRepository clientRepository,
        IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<ClientDetailsDto> Handle(
        GetClientDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var clientDetails = await _clientRepository.GetByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(Client), request.Id);

        var data = _mapper.Map<ClientDetailsDto>(clientDetails);

        return data;
    }
}
