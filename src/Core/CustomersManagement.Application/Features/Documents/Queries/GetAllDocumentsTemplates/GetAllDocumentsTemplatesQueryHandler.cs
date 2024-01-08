using AutoMapper;
using CustomersManagement.Application.Contracts.Logging;
using CustomersManagement.Application.Contracts.Persistence;
using MediatR;

namespace CustomersManagement.Application.Features.Documents.Queries.GetAllDocumentsTemplates;

public class GetAllDocumentsTemplatesQueryHandler : IRequestHandler<GetAllDocumentsTemplatesQuery, List<DocumentDto>>
{
    public readonly IDocumentRepository _documentRepository;
    public readonly IMapper _mapper;
    private readonly IAppLogger<GetAllDocumentsTemplatesQueryHandler> _logger;
    public GetAllDocumentsTemplatesQueryHandler(
        IDocumentRepository documentRepository,
        IMapper mapper,
        IAppLogger<GetAllDocumentsTemplatesQueryHandler> logger)
    {
        _documentRepository = documentRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<DocumentDto>> Handle(
        GetAllDocumentsTemplatesQuery request,
        CancellationToken cancellationToken)
    {
        //todo:
        //implement double checking with database if I want user's custom naming for files 
        //move to separete service class :D
        //take care of that custom mapping

        //just a temporary solution as long as I use FileSystem to store documents 
        var localDirectoryPath = Path.Combine("C:\\Users\\Krzysiek\\repos\\CustomersManagement\\src\\TmpFilesStore\\Templates");
        var directory = new DirectoryInfo(localDirectoryPath);
        if (!directory.Exists)
        {
            throw new DirectoryNotFoundException($"The directory does not exist. Current dir = {Directory.GetCurrentDirectory()}Directory: {localDirectoryPath}");
        }

        var files = directory.GetFileSystemInfos();

        var data = MapToDocumentDto(files);

        _logger.LogInformation("All documents were retrieved successfullly");
        return data;
    }

    private static List<DocumentDto> MapToDocumentDto(FileSystemInfo[] files)
    {
        var list = new List<DocumentDto>();
        foreach (var file in files)
        {
            var document = new DocumentDto
            {
                FileName = file.Name,
                RemotePath = file.FullName
            };

            list.Add(document);
        }

        return list;
    }
}
