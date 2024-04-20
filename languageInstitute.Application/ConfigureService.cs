

using FluentValidation.AspNetCore;
using languageInstitute.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace languageInstitute.Application;

public static class ConfigureService
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {

        services.AddAutoMapper(typeof(StudentProfile));
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();

        return services;
    }
}
