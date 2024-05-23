using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using MediatR;

namespace CustomersManagement.Application.Features.Emails.Queries.GetEmailTemplates;

public class GetEmailTemplatesQueryHandler : IRequestHandler<GetEmailTemplatesQuery, IEnumerable<EmailTemplateDto>>
{
    private readonly IEmailRepository _emailRepository;
    private readonly IMapper _mapper;

    public GetEmailTemplatesQueryHandler(
        IEmailRepository emailRepository,
        IMapper mapper)
    {
        _emailRepository = emailRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmailTemplateDto>> Handle(
        GetEmailTemplatesQuery request,
        CancellationToken cancellationToken)
    {
        var templates = await _emailRepository.GetByType(request.Type);

        var data = _mapper.Map<IEnumerable<EmailTemplateDto>>(templates);

        return data;
    }
}
