using AutoMapper;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.DivingSchool;
using CustomersManagement.UI.Models.Emloyee;
using CustomersManagement.UI.Models.Newsletter;
using CustomersManagement.UI.Models.Shared;
using CustomersManagement.UI.Models.TravelAgency;
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
        CreateMap<CustomerTourDto, CustomerActivityVM>();
        CreateMap<CustomerTourDetailsDto, CustomerActivityDetailsVM>();

        CreateMap<TourDetailsVM, CreateTourCommand>();
        CreateMap<TourDto, ActivityVM>();
        CreateMap<TourDetailsDto, TourDetailsVM>();
        CreateMap<TourDetailsVM, UpdateTourCommand>();
        CreateMap<TourParticipantDto, ActivityParticipantVM>();

        CreateMap<DivingSchoolCustomerDetailsVM, CreateDivingSchoolCustomerCommand>();
        CreateMap<DivingSchoolCustomerDto, CustomerVM>();
        CreateMap<DivingSchoolCustomerDetailsDto, DivingSchoolCustomerDetailsVM>();
        CreateMap<DivingSchoolCustomerDetailsVM, UpdateDivingSchoolCustomerCommand>();
        CreateMap<CustomerCourseDto, CustomerActivityVM>();
        CreateMap<CustomerCourseDetailsDto, CustomerActivityDetailsVM>();

        CreateMap<CourseDetailsVM, CreateCourseCommand>();
        CreateMap<CourseDto, ActivityVM>();
        CreateMap<CourseDetailsDto, CourseDetailsVM>();
        CreateMap<CourseParticipantDto, ActivityParticipantVM>();
        CreateMap<CourseDetailsVM, UpdateTourCommand>();

        CreateMap<EmailVM, SendEmailCommand>();

        CreateMap<Employee, EmployeeVM>();
        CreateMap<RegisterVM, RegisterNewUserCommand>();

        //CreateMap<RegisterVM, RegistrationRequest>()
        //    .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email));
    }
}
