using CustomersManagement.Domain;
using CustomersManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Persistence.DatabaseContext;

public class ClientsDatabaseContext : DbContext
{
    public ClientsDatabaseContext(DbContextOptions<ClientsDatabaseContext> options) : base(options)
    {

    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientsDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>()
            .HasMany(e => e.Documents)
            .WithOne(e => e.Client)
            .HasForeignKey(e => e.Id)
            .IsRequired(false);
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
