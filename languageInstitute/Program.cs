using languageInstitute;
using languageInstitute.Context;
using Microsoft.EntityFrameworkCore;
using System.Runtime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


var configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var configuration = configurationBuilder.Build();

//IOptions
//IOptionsSnapshot
//IOptionsMonitor

builder.Services.Configure<MySettings>(configuration.GetSection("MySettings"));

string connectionString = "Data Source=nanaga-parbat.liara.cloud,32305;Database=languageinstituteDb;User Id=sa;Password=w0UqMWHS0vl7XQSfHhqyttF7;encrypt=false;Trust Server Certificate=true;";

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.RegisterPresentationServices();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
