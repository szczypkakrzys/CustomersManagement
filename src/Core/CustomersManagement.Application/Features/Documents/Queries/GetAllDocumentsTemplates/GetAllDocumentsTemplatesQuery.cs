using MediatR;

namespace CustomersManagement.Application.Features.Documents.Queries.GetAllDocumentsTemplates;

public record GetAllDocumentsTemplatesQuery : IRequest<List<DocumentDto>>;
