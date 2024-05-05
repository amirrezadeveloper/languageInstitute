using languageInstitute.Application.Contracts;
using languageInstitute.Domain.Settings;
using languageInstitute.Infrastructure.Identity.Context;
using languageInstitute.Infrastructure.Identity.Entities;
using languageInstitute.Infrastructure.Identity.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace languageInstitute.Infrastructure.Identity;


public static class ConfigureService
{
    public static IServiceCollection RegisterIdentityInfrastructureServices(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        //Option + Database Provider
        services.AddDbContext<ApplicationIdentityContext>(options =>
               options.UseSqlServer(
        connectionString,
                   b => b.MigrationsAssembly(typeof(ApplicationIdentityContext).Assembly.FullName)));

        //Services
        services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationIdentityContext>().AddDefaultTokenProviders();
        services.AddTransient<IAuthenticationService, AuthenticationService>();

        //Config Binding
        services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

        //Add Authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                };
                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        return c.Response.WriteAsync(c.Exception.ToString());
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject("You are not Authorized");
                        return context.Response.WriteAsync(result);
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject("You are not authorized to access this resource");
                        return context.Response.WriteAsync(result);
                    },
                };
            });

        return services;
    }
}
