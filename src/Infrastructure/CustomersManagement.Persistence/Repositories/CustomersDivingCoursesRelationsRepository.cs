using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.DivingSchool;
using CustomersManagement.Persistence.DatabaseContext;

namespace CustomersManagement.Persistence.Repositories;

public class CustomersDivingCoursesRelationsRepository : GenericRepository<CustomersDivingCoursesRelations>, ICustomersDivingCoursesRelationsRepository
{
    public CustomersDivingCoursesRelationsRepository(CustomerDatabaseContext context) : base(context)
    {
    }
}
