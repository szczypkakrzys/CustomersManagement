using AutoMapper;
using CustomersManagement.Application.Models.Identity;
using CustomersManagement.Identity.Models;

namespace CustomersManagement.Identity.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<ApplicationUser, Employee>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
             .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
             .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
    }
}
