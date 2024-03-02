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
            //todo
            //check whether I need two ways mapping
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<CustomerDetailsDto, Customer>().ReverseMap();
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
        }
    }
}
