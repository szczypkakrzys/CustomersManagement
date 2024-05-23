using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.Email;
using MediatR;

namespace CustomersManagement.Application.Features.Emails.Commands.DeleteEmailTemplate;

public class DeleteEmailTemplateCommandHandler : IRequestHandler<DeleteEmailTemplateCommand, Unit>
{
    private readonly IEmailRepository _emailRepository;

    public DeleteEmailTemplateCommandHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task<Unit> Handle(
        DeleteEmailTemplateCommand request,
        CancellationToken cancellationToken)
    {
        var templateToDelete = await _emailRepository.GetByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(EmailTemplate), request.Id);

        await _emailRepository.DeleteAsync(templateToDelete);

        return Unit.Value;
    }
}
