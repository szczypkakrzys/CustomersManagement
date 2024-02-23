using CustomersManagement.Application.Contracts.Persistence;
using MediatR;

namespace CustomersManagement.Application.Features.Documents.Commands.DownloadDocument
{
    public class DownloadDocumentCommandHandler : IRequestHandler<DownloadDocumentCommand, DownloadDocumentResult>
    {
        private readonly IDocumentRepository _documentRepository;

        public DownloadDocumentCommandHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task<DownloadDocumentResult> Handle(DownloadDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var document = await _documentRepository.GetByIdAsync(request.Id);

                var memory = new MemoryStream();
                using (var stream = new FileStream(document.RemotePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                var result = new DownloadDocumentResult
                {
                    Stream = memory,
                    ContentType = document.ContentType,
                    FileName = document.FileName
                };

                return result;
                //todo
                //get document by id should be - and then based on some data like remotePath - download
                //for now just leave it as it is, but change in future to proper way 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
