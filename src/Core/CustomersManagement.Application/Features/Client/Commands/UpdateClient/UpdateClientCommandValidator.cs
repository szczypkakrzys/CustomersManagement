using CustomersManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CustomersManagement.Application.Features.Client.Commands.UpdateClient;

public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
{
    private readonly IClientRepository _clientRepository;
    public UpdateClientCommandValidator(IClientRepository clientRepository)
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .MustAsync(ClientMustExist);

        RuleFor(p => p.FirstName)
          .NotEmpty().WithMessage("{PropertyName is required");

        RuleFor(p => p.LastName)
           .NotEmpty().WithMessage("{PropertyName is required");

        RuleFor(p => p.EmailAddress)
           .NotEmpty().WithMessage("{PropertyName is required");

        RuleFor(q => q)
            .MustAsync(ClientDataUnique)
            .WithMessage("Given client already exists");

        _clientRepository = clientRepository;
    }

    private async Task<bool> ClientMustExist(int id, CancellationToken token)
    {
        var client = await _clientRepository.GetByIdAsync(id);
        return client != null;
    }

    private Task<bool> ClientDataUnique(UpdateClientCommand command, CancellationToken token)
    {
        return _clientRepository.IsClientUnique(
            command.FirstName,
            command.LastName,
            command.EmailAddress);
    }


}