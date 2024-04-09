
using languageInstitute.Business;
using languageInstitute.Contract;
using languageInstitute.Profiles;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace languageInstitute;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentBusiness, StudentBusiness>();
        services.AddAutoMapper(typeof(StudentProfile));
        services.AddFluentValidation();
        return services;
    }
}
