using EAppointment.Domain.Entities;
using EAppointment.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EAppointment.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration _configuration) 
        {
            services.AddDbContext<EAppointmentDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("SQL")));
            services.AddIdentity<User, Role>(action =>
            {
                action.Password.RequiredLength = 1;
                action.Password.RequireUppercase = false;
                action.Password.RequireLowercase = false;
                action.Password.RequireNonAlphanumeric = false;
                action.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<EAppointmentDbContext>();
            return services;
        }
    }
}
