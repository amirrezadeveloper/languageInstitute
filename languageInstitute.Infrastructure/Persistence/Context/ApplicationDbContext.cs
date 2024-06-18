using Microsoft.EntityFrameworkCore;
using System.Reflection;
using languageInstitute.Domain.Entities;


namespace languageInstitute.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Courses> Courses { get; set; }
    public DbSet<Class> Classes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Base");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
