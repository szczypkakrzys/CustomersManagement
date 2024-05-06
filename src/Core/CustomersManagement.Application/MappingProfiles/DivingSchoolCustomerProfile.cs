using AutoMapper;
using CustomersManagement.Application.Features.DivingSchoolCustomers.Commands.CreateDivingSchoolCustomer;
using CustomersManagement.Application.Features.DivingSchoolCustomers.Commands.UpdateDivingSchoolCustomer;
using CustomersManagement.Application.Features.DivingSchoolCustomers.Queries.GetAllCustomerCourses;
using CustomersManagement.Application.Features.DivingSchoolCustomers.Queries.GetAllDivingSchoolCustomers;
using CustomersManagement.Application.Features.DivingSchoolCustomers.Queries.GetCustomerCourseDetails;
using CustomersManagement.Application.Features.DivingSchoolCustomers.Queries.GetDivingSchoolCustomerDetails;
using CustomersManagement.Domain.DivingSchool;

namespace CustomersManagement.Application.MappingProfiles;

public class DivingSchoolCustomerProfile : Profile
{
    public DivingSchoolCustomerProfile()
    {
        CreateMap<DivingSchoolCustomer, DivingSchoolCustomerDto>();
        CreateMap<DivingSchoolCustomer, DivingSchoolCustomerDetailsDto>();
        CreateMap<CreateDivingSchoolCustomerCommand, DivingSchoolCustomer>();
        CreateMap<UpdateDivingSchoolCustomerCommand, DivingSchoolCustomer>();
        CreateMap<DivingCourse, CustomerCourseDto>();
        CreateMap<CustomersDivingCoursesRelations, CustomerCourseDetailsDto>();
    }
}
