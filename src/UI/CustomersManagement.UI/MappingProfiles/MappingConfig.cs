using AutoMapper;
using CustomersManagement.UI.Models.Customers;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<ClientDto, CustomerVM>().ReverseMap();
        CreateMap<ClientDetailsDto, CustomerVM>().ReverseMap();
        CreateMap<CreateClientCommand, CustomerVM>().ReverseMap();
        CreateMap<UpdateClientCommand, CustomerVM>().ReverseMap();
    }
}
