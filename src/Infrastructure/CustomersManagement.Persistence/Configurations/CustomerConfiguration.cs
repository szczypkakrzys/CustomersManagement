using CustomersManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomersManagement.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(
            new Customer
            {
                Id = 1,
                FirstName = "James",
                LastName = "Williams",
                EmailAddress = "jwilliams@email.com"
            },
            new Customer
            {
                Id = 2,
                FirstName = "Richard",
                LastName = "Johson",
                EmailAddress = "rjohson@email.com"
            },
            new Customer
            {
                Id = 3,
                FirstName = "George",
                LastName = "Smith",
                EmailAddress = "gsmith@email.com"
            });

        builder.Property(q => q.FirstName)
            .IsRequired();
        builder.Property(q => q.LastName)
            .IsRequired();
        builder.Property(q => q.EmailAddress)
            .IsRequired();
    }
}
