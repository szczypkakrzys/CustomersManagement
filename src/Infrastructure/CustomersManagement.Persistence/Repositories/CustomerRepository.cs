using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain;
using CustomersManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Persistence.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(CustomerDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IsCustomerUnique(
        string firstName,
        string lastName,
        string emailAddress)
    {
        var result = await _context.Customers
            .AnyAsync(q =>
                q.FirstName == firstName &&
                q.LastName == lastName &&
                q.EmailAddress == emailAddress);

        return !result;
    }
}
