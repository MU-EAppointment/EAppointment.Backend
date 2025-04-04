using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Domain.Entities;
using EAppointment.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EAppointment.Persistence.Repositories.Patients
{
    internal sealed class PatientQueryRepository(EAppointmentDbContext _context) : IQueryRepository<Patient>
    {
        public DbSet<Patient> Table => _context.Set<Patient>();

        public IQueryable<Patient> GetAll() => Table.AsQueryable();

        public async Task<Patient> GetAsync(Guid id) => (await Table.FindAsync(id))!;
    }
}
