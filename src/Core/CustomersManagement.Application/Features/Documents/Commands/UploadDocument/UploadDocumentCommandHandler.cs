using AutoMapper;
using CustomersManagement.Application.Contracts.Logging;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Features.Documents.Helpers;
using CustomersManagement.Domain;
using MediatR;

namespace CustomersManagement.Application.Features.Documents.Commands.CreateDocument;

public class UploadDocumentCommandHandler : IRequestHandler<UploadDocumentCommand, List<UploadDocumentResult>>
{
    private readonly IMapper _mapper;
    private readonly IDocumentRepository _documentRepository;
    private readonly IAppLogger<UploadDocumentCommandHandler> _logger;

    public UploadDocumentCommandHandler(
        IMapper mapper,
        IDocumentRepository documentRepository,
        IAppLogger<UploadDocumentCommandHandler> logger)
    {
        _mapper = mapper;
        _documentRepository = documentRepository;
        _logger = logger;
    }

    public async Task<List<UploadDocumentResult>> Handle(
        UploadDocumentCommand request,
        CancellationToken cancellationToken)
    {
        //todo
        // take a look at documentation examples to properly handle every possible scenerio :)

        var uploadResults = new List<UploadDocumentResult>();

        //todo
        //consider whether it's a good idea to keep all the logic in handler or maybe extract it to some service class 
        foreach (var file in request.Files)
        {
            var uploadResult = new UploadDocumentResult();
            //string trustedFileNameForFileStorage;
            //var untrustedFiles
            //todo;
            //temporarily change path to something like C:\somethig\files
            var path = Path.Combine("C:\\CustomersManagementFilesStorage\\Templates", file.FileName);

            await using FileStream fs = new(path, FileMode.Create);
            await file.CopyToAsync(fs);

            uploadResult.RemotePath = path;
            uploadResults.Add(uploadResult);

            //convert to domain entity object
            //todo
            //use some helper variable


            //conisder using here any mapper method to make that automatic if only possible :)

            //use automapper :)
            var fileConvertableToDbEntity = new UploadDocumentHelper // replace with better solution
            {
                FileName = file.FileName,
                Type = request.Type,
                RemotePath = path,
                ContentType = file.ContentType,
            };


            //todo
            //handle scenerio where given document already exists :)


            //var fileConvertableToDbEntity = (file.FileName, request.Type, path);
            ////var entity = DocumentProfile.MapToDocumentEntity(file.FileName, request.Type, path);
            var documentToCreate = _mapper.Map<Document>(fileConvertableToDbEntity);

            //add to database
            await _documentRepository.CreateAsync(documentToCreate);
        }



        return uploadResults;






        //return record id
        //var result = new DocumentUploadResult();
        //return result;
        //return documentToCreate.Id;
        //throw new NotImplementedException();
    }
}
