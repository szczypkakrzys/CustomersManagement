using CustomersManagement.Domain.DivingSchool;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface IDivingCourseRepository : IGenericRepository<DivingCourse>
{
    Task<DivingCourse> GetByIdWithParticipants(int id);
}
