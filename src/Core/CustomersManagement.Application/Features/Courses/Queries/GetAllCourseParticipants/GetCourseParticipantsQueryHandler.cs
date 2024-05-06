using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.TravelAgency;
using MediatR;

namespace CustomersManagement.Application.Features.Courses.Queries.GetAllCourseParticipants;

public class GetCourseParticipantsQueryHandler : IRequestHandler<GetCourseParticipantsQuery, IEnumerable<CourseParticipantDto>>
{
    private readonly IDivingCourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public GetCourseParticipantsQueryHandler(
        IDivingCourseRepository courseRepository,
        IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseParticipantDto>> Handle(
        GetCourseParticipantsQuery request,
        CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdWithParticipants(request.Id) ??
                       throw new NotFoundException(nameof(Tour), request.Id);

        var result = _mapper.Map<IEnumerable<CourseParticipantDto>>(course.Participants);

        return result;
    }
}
