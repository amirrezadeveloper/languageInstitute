using languageInstitute;
using languageInstitute.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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
