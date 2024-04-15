using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.DivingSchool;
using CustomersManagement.Persistence.DatabaseContext;

namespace CustomersManagement.Persistence.Repositories;

public class DivingCourseRepository : GenericRepository<DivingCourse>, IDivingCourseRepository
{
    public DivingCourseRepository(CustomerDatabaseContext context) : base(context)
    {
    }
}
