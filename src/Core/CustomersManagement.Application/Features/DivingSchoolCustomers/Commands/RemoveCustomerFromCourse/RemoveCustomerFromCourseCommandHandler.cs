using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.DivingSchoolCustomers.Commands.RemoveCustomerFromCourse;

public class RemoveCustomerFromCourseCommandHandler : IRequestHandler<RemoveCustomerFromCourseCommand, Unit>
{
    private readonly ICustomersDivingCoursesRelationsRepository _relationsRepository;

    public RemoveCustomerFromCourseCommandHandler(ICustomersDivingCoursesRelationsRepository relationsRepository)
    {
        _relationsRepository = relationsRepository;
    }

    public async Task<Unit> Handle(RemoveCustomerFromCourseCommand request, CancellationToken cancellationToken)
    {
        var details = await _relationsRepository.GetCustomerCourseDetails(request.CustomerId, request.CourseId) ??
                    throw new NotFoundException($"Relation with customerId: {request.CustomerId} and courseId:", request.CourseId);

        await _relationsRepository.DeleteAsync(details);

        return Unit.Value;
    }
}
