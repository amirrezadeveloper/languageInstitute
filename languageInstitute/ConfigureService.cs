
using languageInstitute.Business;
using languageInstitute.Contract;
using languageInstitute.Profiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using languageInstitute.Context;
using Microsoft.EntityFrameworkCore;

namespace languageInstitute;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentBusiness, StudentBusiness>();
        services.AddAutoMapper(typeof(StudentProfile));
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();

        var configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        var configuration = configurationBuilder.Build();

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("languageInstituteDatabase")));

        return services;
    }
}
