using EAppointment.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace EAppointment.WebAPI.SeedData
{
    public static class SeedAdmin
    {
        public static async Task CreateUserAsync(WebApplication app)
        {
            using IServiceScope? scoped = app.Services.CreateScope();
            UserManager<User>? userManager = scoped.ServiceProvider.GetRequiredService<UserManager<User>>();
            if (!userManager.Users.Any())
            {
                await userManager.CreateAsync(new()
                {
                    FirstName = "Musa",
                    LastName = "Uyumaz",
                    Email = "admin@admin.com",
                    UserName = "admin"
                }, "1");
            }
        }
    }
}
