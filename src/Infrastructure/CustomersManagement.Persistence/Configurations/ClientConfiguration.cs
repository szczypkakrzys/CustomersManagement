using CustomersManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomersManagement.Persistence.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasData(
            new Client
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
