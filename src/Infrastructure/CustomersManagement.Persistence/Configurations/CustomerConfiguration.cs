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
                FirstName = "FirstName",
                LastName = "LastName",
                EmailAddress = "email@email.com"
            });

        //todo
        //define database restriction rules
        builder.Property(q => q.FirstName)
            .IsRequired();
    }
}
