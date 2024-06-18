
using Microsoft.AspNetCore.Identity;

namespace languageInstitute.Infrastructure.Identity.Entities;

//One to One
//Json Proprty
//Owned Type
//TPH

public class ApplicationUser: IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
