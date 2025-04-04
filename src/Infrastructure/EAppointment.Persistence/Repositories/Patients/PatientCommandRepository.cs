using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Domain.Entities;
using EAppointment.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EAppointment.Persistence.Repositories.Patients
{
    internal sealed class PatientCommandRepository(EAppointmentDbContext _context) : ICommandRepository<Patient>
    {
        public DbSet<Patient> Table => _context.Set<Patient>();

        public async Task<Patient> AddAsync(Patient entity) => (await Table.AddAsync(entity)).Entity;

        public async Task DeleteAsync(Guid id)
        {
            Patient? deletedPatient = await Table.FirstOrDefaultAsync(d => d.Id == id);
            deletedPatient!.IsActive = false;
            Update(deletedPatient);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public Patient Update(Patient entity) => Table.Update(entity).Entity;
    }
}
