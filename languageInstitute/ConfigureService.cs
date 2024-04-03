
using languageInstitute.Business;
using languageInstitute.Contract;

namespace languageInstitute;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentBusiness, StudentBusiness>();

        return services;
    }
}
