using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.Email;
using MediatR;

namespace CustomersManagement.Application.Features.Emails.Commands.CreateEmailTemplate;

public class CreateEmailTemplateCommandHandler : IRequestHandler<CreateEmailTemplateCommand, int>
{
    private readonly IEmailRepository _emailRepository;
    private readonly IMapper _mapper;

    public CreateEmailTemplateCommandHandler(
        IEmailRepository emailRepository,
        IMapper mapper)
    {
        _emailRepository = emailRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(
        CreateEmailTemplateCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateEmailTemplateCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid Email Template", validationResult);

        var templateToCreate = _mapper.Map<EmailTemplate>(request);

        await _emailRepository.CreateAsync(templateToCreate);

        return templateToCreate.Id;
    }
}
