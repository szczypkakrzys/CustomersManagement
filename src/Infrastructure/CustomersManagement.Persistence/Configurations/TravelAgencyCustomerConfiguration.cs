using CustomersManagement.Domain.TravelAgency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomersManagement.Persistence.Configurations;

public class TravelAgencyCustomerConfiguration : IEntityTypeConfiguration<TravelAgencyCustomer>
{
    //TODO
    //maybe get rid of seeding data and stick only to validation :)
    public void Configure(EntityTypeBuilder<TravelAgencyCustomer> builder)
    {
        //builder.HasData(
        //    new TravelAgencyCustomer
        //    {
        //        Id = 1,
        //        FirstName = "James",
        //        LastName = "Williams",
        //        EmailAddress = "jwilliams@email.com",
        //        //Address = new Domain.Address
        //        //{
        //        //    Country = "Poland",
        //        //    Voivodeship = "slaskie",
        //        //    PostalCode = "43-300",
        //        //    City = "Bielsko-Biala",
        //        //    Street = "Bielska",
        //        //    HouseNumber = "12/4",
        //        //},
        //        DateOfBirth = new DateOnly(1999, 1, 1),
        //        PhoneNumber = "123123123"
        //    },
        //    new TravelAgencyCustomer
        //    {
        //        Id = 2,
        //        FirstName = "Richard",
        //        LastName = "Johson",
        //        EmailAddress = "rjohson@email.com",
        //        //Address = new Domain.Address
        //        //{
        //        //    Country = "Poland",
        //        //    Voivodeship = "slaskie",
        //        //    PostalCode = "43-300",
        //        //    City = "Bielsko-Biala",
        //        //    Street = "Bielska",
        //        //    HouseNumber = "12/4",
        //        //},
        //        DateOfBirth = new DateOnly(1999, 1, 1),
        //        PhoneNumber = "123123123"
        //    },
        //    new TravelAgencyCustomer
        //    {
        //        Id = 3,
        //        FirstName = "George",
        //        LastName = "Smith",
        //        EmailAddress = "gsmith@email.com",
        //        //Address = new Domain.Address
        //        //{
        //        //    Id = 1,
        //        //    Country = "Poland",
        //        //    Voivodeship = "slaskie",
        //        //    PostalCode = "43-300",
        //        //    City = "Bielsko-Biala",
        //        //    Street = "Bielska",
        //        //    HouseNumber = "12/4",
        //        //},
        //        DateOfBirth = new DateOnly(1999, 1, 1),
        //        PhoneNumber = "123123123"
        //    });

        //builder.Property(q => q.FirstName)
        //    .IsRequired();
        //builder.Property(q => q.LastName)
        //    .IsRequired();
        //builder.Property(q => q.EmailAddress)
        //    .IsRequired();
        ////builder.Property(q => q.Address)
        ////    .IsRequired();
        //builder.Property(q => q.DateOfBirth)
        //    .IsRequired();
        //builder.Property(q => q.PhoneNumber)
        //    .IsRequired();
    }
}
