using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Domain.Entities;
using EAppointment.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EAppointment.Persistence.Repositories.Doctors
{
    internal sealed class DoctorQueryRepository(EAppointmentDbContext _context) : IQueryRepository<Doctor>
    {
        public DbSet<Doctor> Table => _context.Set<Doctor>();

        public IQueryable<Doctor> GetAll() => Table.AsQueryable();

        public async Task<Doctor> GetAsync(Guid id) => (await Table.FindAsync(id))!;
    }
}
