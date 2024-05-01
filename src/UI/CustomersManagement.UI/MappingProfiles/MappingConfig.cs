using AutoMapper;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.Shared;
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
        CreateMap<CustomerTourDto, CustomerTourVM>();
        CreateMap<CustomerTourDetailsDto, CustomerTourDetailsVM>();

        CreateMap<TourDetailsVM, CreateTourCommand>();
        CreateMap<TourDto, TourVM>();
        CreateMap<TourDetailsDto, TourDetailsVM>();
        CreateMap<TourDetailsVM, UpdateTourCommand>();
        CreateMap<TourParticipantDto, TourParticipantVM>();

        CreateMap<RegisterVM, RegistrationRequest>()
            .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email));
    }
}
