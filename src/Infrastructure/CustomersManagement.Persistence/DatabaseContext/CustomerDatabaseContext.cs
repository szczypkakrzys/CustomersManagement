using CustomersManagement.Application.Contracts.Identity;
using CustomersManagement.Domain;
using CustomersManagement.Domain.Common;
using CustomersManagement.Domain.DivingSchool;
using CustomersManagement.Domain.Notification;
using CustomersManagement.Domain.TravelAgency;
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

    public DbSet<TravelAgencyCustomer> TravelAgencyCustomers { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<CustomersToursRelations> CustomersToursRelations { get; set; }
    public DbSet<DivingSchoolCustomer> DivingSchoolCustomers { get; set; }
    public DbSet<DivingCourse> DivingCourses { get; set; }
    public DbSet<CustomersDivingCoursesRelations> CustomersDivingCoursesRelations { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Address>()
           .HasOne(e => e.TravelAgencyCustomer)
           .WithOne(e => e.Address)
           .HasForeignKey<TravelAgencyCustomer>(e => e.AddressId)
           .IsRequired();

        modelBuilder.Entity<Address>()
            .HasOne(e => e.DivingSchoolCustomer)
            .WithOne(e => e.Address)
            .HasForeignKey<DivingSchoolCustomer>(e => e.AddressId)
            .IsRequired();

        modelBuilder.Entity<Tour>()
            .HasMany(e => e.Participants)
            .WithMany(e => e.Tours)
            .UsingEntity<CustomersToursRelations>(
                l => l.HasOne(e => e.Customer)
                        .WithMany(e => e.ToursRelations)
                        .HasForeignKey(e => e.CustomerId),
                r => r.HasOne(e => e.Tour)
                        .WithMany(e => e.TourRelations)
                        .HasForeignKey(e => e.TourId));

        modelBuilder.Entity<DivingCourse>()
            .HasMany(e => e.Participants)
            .WithMany(e => e.DivingCourses)
            .UsingEntity<CustomersDivingCoursesRelations>(
                l => l.HasOne(e => e.Customer)
                        .WithMany(e => e.DivingCoursesRelations)
                        .HasForeignKey(e => e.CustomerId),
                r => r.HasOne(e => e.DivingCourse)
                        .WithMany(e => e.DivingCourseRelations)
                        .HasForeignKey(e => e.DivingCourseId));
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
            else
            {
                entry.Property(nameof(BaseEntity.TimeCreatedInUtc)).IsModified = false;
                entry.Property(nameof(BaseEntity.CreatedBy)).IsModified = false;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
