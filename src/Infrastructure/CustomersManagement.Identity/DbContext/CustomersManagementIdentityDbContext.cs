using CustomersManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Identity.DbContext;

public class CustomersManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public CustomersManagementIdentityDbContext(DbContextOptions<CustomersManagementIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(CustomersManagementIdentityDbContext).Assembly);
    }
}
