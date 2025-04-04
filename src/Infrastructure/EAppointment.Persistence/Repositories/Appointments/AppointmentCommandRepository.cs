using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Domain.Entities;
using EAppointment.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EAppointment.Persistence.Repositories.Appointments
{
    internal sealed class AppointmentCommandRepository(EAppointmentDbContext _context) : ICommandRepository<Appointment>
    {
        public DbSet<Appointment> Table => _context.Set<Appointment>();

        public async Task<Appointment> AddAsync(Appointment entity) => (await Table.AddAsync(entity)).Entity;

        public async Task DeleteAsync(Guid id)
        {
            Appointment? deletedAppointment = await Table.FirstOrDefaultAsync(d => d.Id == id);
            deletedAppointment!.IsActive = false;
            Update(deletedAppointment);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public Appointment Update(Appointment entity) => Table.Update(entity).Entity;
    }
}
