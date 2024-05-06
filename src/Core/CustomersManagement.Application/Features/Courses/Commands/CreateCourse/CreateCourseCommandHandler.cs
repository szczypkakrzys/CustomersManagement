using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.DivingSchool;
using MediatR;

namespace CustomersManagement.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IDivingCourseRepository _courseRepository;

    public CreateCourseCommandHandler(
        IMapper mapper,
        IDivingCourseRepository courseRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
    }

    public async Task<int> Handle(
        CreateCourseCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateCourseCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid Course", validationResult);

        var courseToCreate = _mapper.Map<DivingCourse>(request);

        await _courseRepository.CreateAsync(courseToCreate);

        return courseToCreate.Id;
    }
}
