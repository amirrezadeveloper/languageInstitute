

namespace languageInstitute;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services, string connectionString)
    {
        services.AddHealthChecks().AddSqlServer(connectionString);
        return services;
    }
}
