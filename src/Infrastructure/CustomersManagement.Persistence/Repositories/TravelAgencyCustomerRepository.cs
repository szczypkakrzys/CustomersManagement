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

    public new async Task<TravelAgencyCustomer?> GetByIdAsync(int id)
    {
        return await _context.Set<TravelAgencyCustomer>()
                            .Include(p => p.Address)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<TravelAgencyCustomer> GetByIdWithTours(int id)
    {
        var customer = await _context.Set<TravelAgencyCustomer>()
                                    .Include(p => p.Tours)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(q => q.Id == id);

        return customer;
    }

    public new async Task DeleteAsync(TravelAgencyCustomer customer)
    {
        _context.Addresses.Remove(customer.Address);
        _context.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public new async Task UpdateAsync(TravelAgencyCustomer customer)
    {
        if (await IsDifferentFromDatabaseValue(customer.Address))
            _context.Entry(customer.Address).State = EntityState.Modified;

        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
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

    public async Task<IEnumerable<TravelAgencyCustomer>> GetCustomersByDateOfBirth(DateOnly date)
    {
        return await _context.TravelAgencyCustomers
           .Where(customer => customer.DateOfBirth.Day == date.Day
                              && customer.DateOfBirth.Month == date.Month)
           .ToListAsync();
    }
}
