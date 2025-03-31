using EAppointment.Domain.Entities.Commons;

namespace EAppointment.Application.Abstractions.Repositories.Commons
{
    public interface IQueryRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
