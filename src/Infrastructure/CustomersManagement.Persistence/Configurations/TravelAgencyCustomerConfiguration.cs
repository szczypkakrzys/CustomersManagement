using CustomersManagement.Domain.TravelAgency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomersManagement.Persistence.Configurations;

public class TravelAgencyCustomerConfiguration : IEntityTypeConfiguration<TravelAgencyCustomer>
{
    public void Configure(EntityTypeBuilder<TravelAgencyCustomer> builder)
    {

    }
}
