using CustomersManagement.Domain;
using CustomersManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Persistence.DatabaseContext;

public class CustomerDatabaseContext : DbContext
{
    public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> options) : base(options)
    {

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
            entry.Entity.TimeLastModified = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
                entry.Entity.TimeCreated = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
