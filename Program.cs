using CureWell.Database;
using CureWell.Models;
using CureWell.Repository;
using CureWell.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDoctorRepository,DoctorRepository>();
builder.Services.AddScoped<IDoctorSpecializationRepository,DoctorSpecializationRepository>();
builder.Services.AddScoped<IDoctorSurgeryRepository,DoctorSurgeryRepository>();
builder.Services.AddScoped<ISpecializationRepository,SpecializationRepository>();
builder.Services.AddScoped<ICureWellService,CureWellService>();


var connectionString = builder.Configuration.GetConnectionString("mysql");
builder.Services.AddDbContext<CureWellDbContext>(options => {
    options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
});

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
