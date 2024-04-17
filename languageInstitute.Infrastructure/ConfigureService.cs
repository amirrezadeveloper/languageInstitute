using languageInstitute.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace languageInstitute.Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, string connectionString)
        {


            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
