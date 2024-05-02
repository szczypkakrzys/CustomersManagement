using AutoMapper;
using CustomersManagement.Application.Features.Courses.Commands.CreateCourse;
using CustomersManagement.Application.Features.Courses.Commands.UpdateCourse;
using CustomersManagement.Application.Features.Courses.Queries.GetAllCourseParticipants;
using CustomersManagement.Application.Features.Courses.Queries.GetAllCourses;
using CustomersManagement.Application.Features.Courses.Queries.GetCourseDetails;
using CustomersManagement.Domain.DivingSchool;

namespace CustomersManagement.Application.MappingProfiles;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<DivingCourse, CourseDto>();
        CreateMap<DivingCourse, CourseDetailsDto>();
        CreateMap<CreateCourseCommand, DivingCourse>();
        CreateMap<UpdateCourseCommand, DivingCourse>();
        CreateMap<DivingSchoolCustomer, CourseParticipantDto>();
    }
}
