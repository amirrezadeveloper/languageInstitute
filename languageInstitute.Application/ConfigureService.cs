
 
using languageInstitute.Domain.Contracts;
using languageInstitute.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace languageInstitute.Application;

public static class ConfigureService
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        return services;
    }
}
