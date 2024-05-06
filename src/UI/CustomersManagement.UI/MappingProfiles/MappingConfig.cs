﻿using AutoMapper;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.Customers;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<CustomerDto, CustomerVM>().ReverseMap();
        CreateMap<CustomerDetailsDto, CustomerVM>().ReverseMap();
        CreateMap<CreateCustomerCommand, CustomerVM>().ReverseMap();
        CreateMap<UpdateCustomerCommand, CustomerVM>().ReverseMap();
        CreateMap<RegisterVM, RegistrationRequest>()
            .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email));
    }
}
