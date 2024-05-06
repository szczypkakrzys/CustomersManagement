using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.DivingSchool;
using MediatR;

namespace CustomersManagement.Application.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
{
    private readonly IDivingCourseRepository _courseRepository;

    public DeleteCourseCommandHandler(IDivingCourseRepository courseRepository) =>
        _courseRepository = courseRepository;

    public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var courseToDelete = await _courseRepository.GetByIdAsync(request.Id) ??
                    throw new NotFoundException(nameof(DivingCourse), request.Id);

        await _courseRepository.DeleteAsync(courseToDelete);

        return Unit.Value;
    }
}
