using AutoMapper;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.Shared;
using CustomersManagement.UI.Models.TravelAgencyCustomers;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<TravelAgencyCustomerDto, CustomerVM>();
        CreateMap<TravelAgencyCustomerDetailsDto, TravelAgencyCustomerDetailsVM>();
        CreateMap<AddressDto, AddressVM>().ReverseMap();
        CreateMap<AddressVM, CreateAddressDto>();
        CreateMap<TravelAgencyCustomerDetailsVM, CreateTravelAgencyCustomerCommand>();
        CreateMap<TravelAgencyCustomerDetailsVM, UpdateTravelAgencyCustomerCommand>();
        //CreateMap<CustomerDetailsDto, CustomerVM>().ReverseMap();
        //CreateMap<CreateCustomerCommand, CustomerVM>().ReverseMap();
        //CreateMap<UpdateCustomerCommand, CustomerVM>().ReverseMap();
        CreateMap<RegisterVM, RegistrationRequest>()
            .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email));
    }
}
