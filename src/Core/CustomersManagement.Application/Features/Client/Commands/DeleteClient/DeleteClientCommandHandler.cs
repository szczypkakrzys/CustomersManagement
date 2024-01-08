using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.Client.Commands.DeleteClient;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
{
    private readonly IClientRepository _clientRepository;

    public DeleteClientCommandHandler(IClientRepository clientRepository) =>
        _clientRepository = clientRepository;

    public async Task<Unit> Handle(
        DeleteClientCommand request,
        CancellationToken cancellationToken)
    {
        var clientToDelete = await _clientRepository.GetByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(Client), request.Id);

        await _clientRepository.DeleteAsync(clientToDelete);

        return Unit.Value;
    }
}
