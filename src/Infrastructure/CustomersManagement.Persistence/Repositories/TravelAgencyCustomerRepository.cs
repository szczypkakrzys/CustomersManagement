using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.TravelAgency;
using CustomersManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Persistence.Repositories;

public class TravelAgencyCustomerRepository : GenericRepository<TravelAgencyCustomer>, ITravelAgencyCustomerRepository
{
    public TravelAgencyCustomerRepository(CustomerDatabaseContext context) : base(context)
    {
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
