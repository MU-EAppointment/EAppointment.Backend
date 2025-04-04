using EAppointment.Application.Features.Auths.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace EAppointment.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
            services.AddScoped<AuthRules>();
            return services;
        }
    }
}
