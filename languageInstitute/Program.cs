using Asp.Versioning;
using languageInstitute;
using languageInstitute.Application;
using languageInstitute.Infrastructure;
using languageInstitute.Infrastructure.Identity;
using languageInstitute.Middlewares;


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
string userDatabaseConnectionString = configuration.GetConnectionString("UserDatabase");

builder.Services
    .RegisterApplicationServices()
    .RegisterIdentityInfrastructureServices(builder.Configuration, userDatabaseConnectionString)
    .RegisterInfrastructureServices(connectionString)
    .RegisterPresentationServices(connectionString);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var apiVersioningBuilder = builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ReportApiVersions = true; 
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
});


var app = builder.Build();

app.UseGlobalException();

app.MapHealthChecks("/healthz");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseEndpoints(e =>
//{
//    e.MapControllers();
//    e.MapHealthChecks("/healthz");
//});


app.Run();
