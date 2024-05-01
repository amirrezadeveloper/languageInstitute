using languageInstitute.Infrastructure.Identity.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;



namespace languageInstitute.Infrastructure.Identity.Context;

public class ApplicationIdentityContext : IdentityDbContext<ApplicationUser>
{
        //public ApplicationIdentityContext(DbContextOptions<ApplicationIdentityContext> options): base(options)
        //{
        //}
}
