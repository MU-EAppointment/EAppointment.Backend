﻿using Microsoft.Extensions.DependencyInjection;

namespace EAppointment.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            return services;
        }
    }
}
