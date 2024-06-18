using languageInstitute.Application.Contracts;
using languageInstitute.Infrastructure.Context;
using languageInstitute.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace languageInstitute.Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("languageInstitute")));
     

            services.AddScoped<IClasstService, StudentService>();

            return services;
        }
    }
}

