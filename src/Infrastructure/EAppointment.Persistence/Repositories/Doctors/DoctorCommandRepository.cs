using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Domain.Entities;
using EAppointment.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EAppointment.Persistence.Repositories.Doctors
{
    internal sealed class DoctorCommandRepository(EAppointmentDbContext _context) : ICommandRepository<Doctor>
    {
        public DbSet<Doctor> Table => _context.Set<Doctor>();

        public async Task<Doctor> AddAsync(Doctor entity) => (await Table.AddAsync(entity)).Entity;

        public async Task DeleteAsync(Guid id)
        {
            Doctor? deletedDoctor = await Table.FirstOrDefaultAsync(d => d.Id == id);
            deletedDoctor!.IsActive = false;
            Update(deletedDoctor);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public Doctor Update(Doctor entity) => Table.Update(entity).Entity;
    }
}
