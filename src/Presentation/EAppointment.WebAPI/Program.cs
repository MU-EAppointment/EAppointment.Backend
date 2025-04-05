using EAppointment.Application;
using EAppointment.Domain.Entities;
using EAppointment.Infrastructure;
using EAppointment.Persistence;
using EAppointment.WebAPI.SeedData;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.WithOrigins("", "").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

SeedAdmin.CreateUserAsync(app).Wait();

app.Run();
