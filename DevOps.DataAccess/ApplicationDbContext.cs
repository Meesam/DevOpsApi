using DevOps.Models.AppModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DevOps.DataAccess;

public class ApplicationDbContext: IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<EmailAddress> EmailAddresses { get; set; }

    public DbSet<Address> Address { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<ProjectItem> ProjectItems { get; set; }

    public DbSet<AppMenu> AppMenus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
               .Property(b => b.CreatedDate)
               .HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Customer>()
            .Property(b => b.UpdatedDate)
            .HasDefaultValueSql("getdate()");

        modelBuilder.Entity<EmailAddress>()
               .Property(b => b.CreatedDate)
               .HasDefaultValueSql("getdate()");

        modelBuilder.Entity<EmailAddress>()
            .Property(b => b.UpdatedDate)
            .HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Address>()
              .Property(b => b.CreatedDate)
              .HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Address>()
            .Property(b => b.UpdatedDate)
            .HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Project>()
               .Property(b => b.CreatedDate)
               .HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Project>()
            .Property(b => b.UpdatedDate)
            .HasDefaultValueSql("getdate()");

        modelBuilder.Entity<ProjectItem>()
              .Property(b => b.CreatedDate)
              .HasDefaultValueSql("getdate()");

        modelBuilder.Entity<ProjectItem>()
            .Property(b => b.UpdatedDate)
            .HasDefaultValueSql("getdate()");


        base.OnModelCreating(modelBuilder);
 
    }
}