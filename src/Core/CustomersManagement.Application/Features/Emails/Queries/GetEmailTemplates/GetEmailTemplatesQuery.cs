using CustomersManagement.Domain.Email;
using MediatR;

namespace CustomersManagement.Application.Features.Emails.Queries.GetEmailTemplates;

public record GetEmailTemplatesQuery(EmailType Type) : IRequest<IEnumerable<EmailTemplateDto>>;
