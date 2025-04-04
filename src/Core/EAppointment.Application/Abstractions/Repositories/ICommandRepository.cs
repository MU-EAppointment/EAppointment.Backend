using EAppointment.Domain.Entities.Commons;

namespace EAppointment.Application.Abstractions.Repositories
{
    public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        T Update(T entity);
        Task DeleteAsync(Guid id);
        Task SaveAsync();
    }
}
