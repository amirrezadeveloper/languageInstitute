
using languageInstitute.Business;
using languageInstitute.Contract;
using languageInstitute.Profiles;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace languageInstitute;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
    {
       
        services.AddAutoMapper(typeof(StudentProfile));
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("languageInstituteDatabase")));

        return services;
    }
}
