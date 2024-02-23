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
    public DbSet<Document> Documents { get; set; }
    public DbSet<FormFillRulesSet> FormFillRulesSets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientsDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Client>()
            .HasMany(client => client.Documents)
            .WithOne(document => document.Client)
            .HasForeignKey(document => document.ClientId)
            .IsRequired(false);

        modelBuilder.Entity<Document>()
            .HasOne(document => document.FormFillRulesSet)
            .WithOne(formFillRulesSet => formFillRulesSet.Document)
            .HasForeignKey<FormFillRulesSet>(formFillRulesSet => formFillRulesSet.DocumentId)
            .IsRequired(false);

        modelBuilder.Entity<FormFillRulesSet>()
            .HasOne(formFillRulesSet => formFillRulesSet.Document)
            .WithOne(document => document.FormFillRulesSet)
            .HasForeignKey<FormFillRulesSet>(formFillRulesSet => formFillRulesSet.DocumentId)
            .IsRequired();
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
