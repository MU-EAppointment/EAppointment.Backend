using EAppointment.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;

namespace EAppointment.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
