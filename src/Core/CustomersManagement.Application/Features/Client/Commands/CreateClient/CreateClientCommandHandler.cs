using AutoMapper;
using CustomersManagement.Application.Contracts.Logging;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.Client.Commands.CreateClient;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;
    private readonly IAppLogger<CreateClientCommandHandler> _logger;

    public CreateClientCommandHandler(
        IMapper mapper,
        IClientRepository clientRepository,
        IAppLogger<CreateClientCommandHandler> logger)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
        _logger = logger;
    }

    public async Task<int> Handle(
        CreateClientCommand request,
        CancellationToken cancellationToken)
    {
        //todo
        //validate incoming data
        var validator = new CreateClientCommandValidator(_clientRepository);
        var validtionResult = await validator.ValidateAsync(request);

        if (validtionResult.Errors.Any())
        {
            _logger.LogWarning("Validation erros in create request for {0}", nameof(Client));
            throw new BadRequestException("Invalid Client", validtionResult);
        }

        //convert to domain entity object
        var clientToCreate = _mapper.Map<Domain.Client>(request);

        //add to database
        await _clientRepository.CreateAsync(clientToCreate);

        //return record id
        return clientToCreate.Id;
    }
}
