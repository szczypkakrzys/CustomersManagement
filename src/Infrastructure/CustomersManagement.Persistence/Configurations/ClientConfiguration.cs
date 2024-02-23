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
                FirstName = "TesterImie",
                LastName = "TesterNazwisko",
                EmailAddress = "testertester@email.com"
            },
            new Client
            {
                Id = 2,
                FirstName = "Jan",
                LastName = "Kowalski",
                EmailAddress = "jkowalski@email.com"
            },
            new Client
            {
                Id = 3,
                FirstName = "Andrzej",
                LastName = "Nowak",
                EmailAddress = "anowak@email.com"
            });

        //todo
        //define database restriction rules
        builder.Property(q => q.FirstName)
            .IsRequired();
    }
}
