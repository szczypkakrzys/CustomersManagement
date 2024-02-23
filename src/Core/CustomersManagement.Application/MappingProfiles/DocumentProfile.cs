using AutoMapper;
using CustomersManagement.Application.Features.Documents.Enums;
using CustomersManagement.Application.Features.Documents.Helpers;
using CustomersManagement.Application.Features.Documents.Queries.GetAllDocumentsTemplates;
using CustomersManagement.Domain;

namespace CustomersManagement.Application.MappingProfiles;

public class DocumentProfile : Profile
{
    public DocumentProfile()
    {//todo - rethink reverse mapping in all classes
        CreateMap<Document, DocumentDto>().ReverseMap();
        CreateMap<UploadDocumentHelper, Document>().ReverseMap();
    }
    public Document MapToDocumentEntity(string fileName, DocumentType type, string remotePath)
    {
        return new Document
        {
            FileName = fileName,
            Type = type.ToString(),
            RemotePath = remotePath
        };
    }
}
