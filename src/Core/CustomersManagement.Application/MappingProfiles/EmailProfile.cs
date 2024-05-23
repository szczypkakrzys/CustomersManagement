using AutoMapper;
using CustomersManagement.Application.Features.Emails.Commands.CreateEmailTemplate;
using CustomersManagement.Application.Features.Emails.Queries.GetEmailTemplates;
using CustomersManagement.Domain.Email;

namespace CustomersManagement.Application.MappingProfiles;

public class EmailProfile : Profile
{
    public EmailProfile()
    {
        CreateMap<EmailTemplate, EmailTemplateDto>();
        CreateMap<CreateEmailTemplateCommand, EmailTemplate>();
    }
}
