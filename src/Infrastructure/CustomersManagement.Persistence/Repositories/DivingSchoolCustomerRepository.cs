using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.DivingSchool;
using CustomersManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Persistence.Repositories;

public class DivingSchoolCustomerRepository : GenericRepository<DivingSchoolCustomer>, IDivingSchoolCustomerRepository
{
    public DivingSchoolCustomerRepository(CustomerDatabaseContext context) : base(context)
    {
    }

    public async Task<DivingSchoolCustomer> GetByIdWithTours(int id)
    {
        var customer = await _context.Set<DivingSchoolCustomer>()
                                    .Include(p => p.DivingCourses)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(q => q.Id == id);

        return customer;
    }

    public async Task<bool> IsCustomerUnique(
         string firstName,
         string lastName,
         string emailAddress)
    {
        var result = await _context.TravelAgencyCustomers
            .AnyAsync(q =>
                q.FirstName == firstName &&
                q.LastName == lastName &&
                q.EmailAddress == emailAddress);

        return !result;
    }
}