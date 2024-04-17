using AutoMapper;
using CustomersManagement.Application.Features.Customer.Commands.CreateCustomer;
using CustomersManagement.Application.Features.Customer.Commands.UpdateCustomer;
using CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;
using CustomersManagement.Application.Features.Customer.Queries.GetCustomerDetails;
using CustomersManagement.Application.Features.Shared;
using CustomersManagement.Application.Features.TravelAgencyCustomer.Commands.CreateTravelAgencyCustomer;
using CustomersManagement.Application.MappingProfiles.Customs;
using CustomersManagement.Domain;
using CustomersManagement.Domain.TravelAgency;

namespace CustomersManagement.Application.MappingProfiles;

public class TravelAgencyCustomerProfile : Profile
{
    public TravelAgencyCustomerProfile()
    {
        CreateMap<TravelAgencyCustomer, TravelAgencyCustomerDto>();

        CreateMap<TravelAgencyCustomer, TravelAgencyCustomerDetailsDto>();

        CreateMap<TravelAgencyCustomerDetailsDto, TravelAgencyCustomer>()
            .ForMember(dest => dest.Tours, opt => opt.Ignore())
            .ForMember(dest => dest.ToursRelations, opt => opt.Ignore())
            .ForMember(dest => dest.TimeCreatedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.TimeLastModifiedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

        CreateMap<CreateTravelAgencyCustomerCommand, TravelAgencyCustomer>()
            .ForMember(dest => dest.AddressId, opt => opt.Ignore())
            .ForMember(dest => dest.Tours, opt => opt.Ignore())
            .ForMember(dest => dest.ToursRelations, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.TimeCreatedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.TimeLastModifiedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

        CreateMap<UpdateTravelAgencyCustomerCommand, TravelAgencyCustomer>()
            .ForMember(dest => dest.Tours, opt => opt.Ignore())
            .ForMember(dest => dest.ToursRelations, opt => opt.Ignore())
            .ForMember(dest => dest.TimeCreatedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.TimeLastModifiedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

        CreateMap<DateTime, DateOnly>().ConvertUsing(new DateTimeToDateOnlyConverter());

        CreateMap<Address, AddressDto>();

        CreateMap<AddressDto, Address>()
            .ForMember(dest => dest.TravelAgencyCustomer, opt => opt.Ignore())
            .ForMember(dest => dest.DivingSchoolCustomer, opt => opt.Ignore())
            .ForMember(dest => dest.TimeCreatedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.TimeLastModifiedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

        CreateMap<CreateAddressDto, Address>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.TravelAgencyCustomer, opt => opt.Ignore())
            .ForMember(dest => dest.DivingSchoolCustomer, opt => opt.Ignore())
            .ForMember(dest => dest.TimeCreatedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.TimeLastModifiedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
    }
}
