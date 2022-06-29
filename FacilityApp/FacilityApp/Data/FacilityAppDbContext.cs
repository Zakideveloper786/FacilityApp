
using FacilityApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;


namespace FacilityApp.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<FacilityAppDbContext>
{
    public FacilityAppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FacilityAppDbContext>();
        optionsBuilder.UseSqlServer("Server=.;Database=FacilityApp;Trusted_Connection=True;");

        return new FacilityAppDbContext(optionsBuilder.Options);
    }
}
public class FacilityAppDbContext :DbContext
{
    public FacilityAppDbContext(DbContextOptions<FacilityAppDbContext> options) : base(options)
    {
    }

    public DbSet<Flat> Flat {  get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<VisitingPurpose> VisitingPurpose { get; set; }


    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<Building> Building { get; set; }
    public DbSet<Lead> Lead { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<TenantUser> tenantUsers { get; set; }

    public DbSet<Tenant> Tenant { get; set; }
    public DbSet<TenantFlatDetails> TenantFlatDetails { get; set; }



    public DbSet<Maintenance> Maintanance { get; set; }
    public DbSet<IssueType> IssueTypes { get; set; }
    public DbSet<Frequency> Frequency { get; set; }



    public DbSet<Parking> Parking { get; set; }
    public DbSet<FlatType> FlatTypes { get; set; }







    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
         .SelectMany(t => t.GetProperties()))
         {
           if(property.ClrType == typeof(string))
            {
                if (property.GetMaxLength() == null)
                    property.SetMaxLength(500);
            }
            if (property.ClrType == typeof(decimal))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
        }
         
        
    }

   

}
