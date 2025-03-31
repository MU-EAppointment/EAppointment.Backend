using EAppointment.Domain.Entities.Commons;

namespace EAppointment.Application.Abstractions.Repositories.Commons
{
    public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task SaveAsync();
    }
}
