using AutoMapper;
using CustomersManagement.Application.Contracts.Logging;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.Client.Commands.UpdateClient;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;
    private readonly IAppLogger<UpdateClientCommandHandler> _logger;

    public UpdateClientCommandHandler(
        IMapper mapper,
        IClientRepository clientRepository,
        IAppLogger<UpdateClientCommandHandler> logger)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(
        UpdateClientCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new UpdateClientCommandValidator(_clientRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation erros in update request for {0} - {1}", nameof(Client), request.Id);
            throw new BadRequestException("Invalid client data", validationResult);
        }

        var clientToUpdate = _mapper.Map<Domain.Client>(request);

        await _clientRepository.UpdateAsync(clientToUpdate);

        return Unit.Value;
    }
}
