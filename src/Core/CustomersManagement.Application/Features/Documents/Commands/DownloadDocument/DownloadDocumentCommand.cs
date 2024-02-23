using MediatR;

namespace CustomersManagement.Application.Features.Documents.Commands.DownloadDocument;

public record DownloadDocumentCommand(int Id) : IRequest<DownloadDocumentResult>;
