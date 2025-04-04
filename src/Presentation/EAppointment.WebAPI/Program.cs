using EAppointment.Application;
using EAppointment.Infrastructure;
using EAppointment.Persistence;

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

app.Run();
