using CustomersManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CustomersManagement.Application.Features.Client.Commands.CreateClient;

public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    private readonly IClientRepository _clientRepository;

    public CreateClientCommandValidator(IClientRepository clientRepository)
    {
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

    private Task<bool> ClientDataUnique(
        CreateClientCommand command,
        CancellationToken token)
    {
        return _clientRepository.IsClientUnique(
            command.FirstName,
            command.LastName,
            command.EmailAddress);
    }
}
