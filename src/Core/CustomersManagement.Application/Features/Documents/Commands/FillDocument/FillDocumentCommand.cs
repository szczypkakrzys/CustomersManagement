using MediatR;

namespace CustomersManagement.Application.Features.Documents.Commands.FillDocument;

public class FillDocumentCommand : IRequest<Unit>
{
    //todo
    //set all neccessary data :)
    public int UserId { get; set; }
    public string FileName { get; set; } = string.Empty;
}
