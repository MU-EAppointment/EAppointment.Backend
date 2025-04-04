using EAppointment.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EAppointment.Persistence.Contexts
{
    internal sealed class EAppointmentDbContext(DbContextOptions options) : IdentityDbContext<User, Role, Guid>(options)
    {
    }
}
