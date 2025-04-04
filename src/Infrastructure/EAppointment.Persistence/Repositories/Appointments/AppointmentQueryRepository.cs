using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Domain.Entities;
using EAppointment.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EAppointment.Persistence.Repositories.Appointments
{
    internal sealed class AppointmentQueryRepository(EAppointmentDbContext _context) : IQueryRepository<Appointment>
    {
        public DbSet<Appointment> Table => _context.Set<Appointment>();

        public IQueryable<Appointment> GetAll() => Table.AsQueryable();

        public async Task<Appointment> GetAsync(Guid id) => (await Table.FindAsync(id))!;
    }
}
