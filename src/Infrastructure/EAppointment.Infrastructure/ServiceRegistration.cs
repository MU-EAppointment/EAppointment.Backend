using EAppointment.Application.Abstractions.Services;
using EAppointment.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EAppointment.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) 
        {
            services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();
            return services;
        }
    }
}
