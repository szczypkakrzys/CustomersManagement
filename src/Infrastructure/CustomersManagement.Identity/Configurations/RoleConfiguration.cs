using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomersManagement.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "456b41e6-001b-43e2-9ac7-e4b043a9d718",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new IdentityRole
            {
                Id = "5bb93284-b026-4ed1-a331-5533e757a143",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            });
    }
}
