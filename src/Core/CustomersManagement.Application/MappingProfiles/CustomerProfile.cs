using AutoMapper;
using CustomersManagement.Application.Features.Customer.Commands.CreateCustomer;
using CustomersManagement.Application.Features.Customer.Commands.UpdateCustomer;
using CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;
using CustomersManagement.Application.Features.Customer.Queries.GetCustomerDetails;
using CustomersManagement.Domain;

namespace CustomersManagement.Application.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, CustomerDetailsDto>();

            CreateMap<CustomerDetailsDto, Customer>()
                .ForMember(dest => dest.TimeCreatedInUtc, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.TimeLastModifiedInUtc, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TimeCreatedInUtc, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.TimeLastModifiedInUtc, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<UpdateCustomerCommand, Customer>()
                .ForMember(dest => dest.TimeCreatedInUtc, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.TimeLastModifiedInUtc, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
        }
    }
}
