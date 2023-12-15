using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevOpsApi.Models;

public class ApplicationDbContext: IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedRoles(builder);
    }

    private static void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
          new IdentityRole() {Name = "Admin", NormalizedName = "Admin", ConcurrencyStamp = "1"},
          new IdentityRole() {Name = "User", NormalizedName = "User", ConcurrencyStamp = "2"},
          new IdentityRole() {Name = "Client", NormalizedName = "Client", ConcurrencyStamp = "3"}
        );
    }
}