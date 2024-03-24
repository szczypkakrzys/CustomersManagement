using AutoMapper;
using CustomersManagement.Application.Models.Identity;
using CustomersManagement.Identity.Models;

namespace CustomersManagement.Identity.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<ApplicationUser, Employee>();
    }
}
