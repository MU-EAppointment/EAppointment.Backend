using EAppointment.Domain.Entities;
using EAppointment.Domain.Entities.Commons;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EAppointment.Persistence.Contexts
{
    internal sealed class EAppointmentDbContext(DbContextOptions<EAppointmentDbContext> options) : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>(options)
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<IdentityUserClaim<Guid>>();
            builder.Ignore<IdentityRoleClaim<Guid>>();
            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<BaseEntity>>? datas = ChangeTracker.Entries<BaseEntity>();
            Parallel.ForEach(datas, data =>
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedAt = DateTime.UtcNow;
                    data.Entity.IsActive = true;
                }
                else if (data.State == EntityState.Modified)
                    data.Entity.UpdatedAt = DateTime.UtcNow;
            });

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
