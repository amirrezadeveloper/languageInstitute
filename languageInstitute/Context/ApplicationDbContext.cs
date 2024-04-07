using languageInstitute.Models;
using Microsoft.EntityFrameworkCore;

namespace languageInstitute.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
}
