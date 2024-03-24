using CustomersManagement.Application.Contracts.Identity;
using CustomersManagement.Domain;
using CustomersManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Persistence.DatabaseContext;

public class CustomerDatabaseContext : DbContext
{
    private readonly IUserService _userService;

    public CustomerDatabaseContext(
        DbContextOptions<CustomerDatabaseContext> options,
        IUserService userService) : base(options)
    {
        _userService = userService;
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.TimeLastModifiedInUtc = DateTime.UtcNow;
            entry.Entity.LastModifiedBy = _userService.UserId;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.TimeCreatedInUtc = DateTime.UtcNow;
                entry.Entity.CreatedBy = _userService.UserId;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
