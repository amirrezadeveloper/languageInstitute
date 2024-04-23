using languageInstitute;
using languageInstitute.Application;
using languageInstitute.Infrastructure;
using languageInstitute.Middlewares;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var configurationBuilder = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
     .AddUserSecrets("cb10458b-0d06-4567-8b57-7a123e1950dc")
     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var configuration = configurationBuilder.Build();

string connectionString = configuration.GetConnectionString("languageInstituteDatabase");

builder.Services
    .RegisterApplicationServices()
    .RegisterInfrastructureServices(connectionString)
    .RegisterPresentationServices();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseGlobalException(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
