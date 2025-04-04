using Microsoft.Extensions.DependencyInjection;

namespace EAppointment.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services) 
        {
            return services;
        }
    }
}
