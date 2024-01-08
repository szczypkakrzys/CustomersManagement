using AutoMapper;
using CustomersManagement.Application.Features.Documents.Queries.GetAllDocumentsTemplates;
using CustomersManagement.Domain;

namespace CustomersManagement.Application.MappingProfiles;

public class DocumentProfile : Profile
{
    public DocumentProfile()
    {
        CreateMap<Document, DocumentDto>().ReverseMap();
    }
}
