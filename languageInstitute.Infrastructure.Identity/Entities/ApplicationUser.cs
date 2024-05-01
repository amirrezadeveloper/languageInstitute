using Microsoft.AspNet.Identity.EntityFramework;

namespace languageInstitute.Infrastructure.Identity.Entities;

public class ApplicationUser: IdentityUser
{
    public string FirstName { get; set; }   
    public string LastName { get; set; }    
}
 