using MediatR;

namespace CustomersManagement.Application.Features.Emails.Commands.DeleteEmailTemplate;

public class DeleteEmailTemplateCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
