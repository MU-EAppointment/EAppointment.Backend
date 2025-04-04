using EAppointment.Domain.Entities.Commons;

namespace EAppointment.Application.Abstractions.Repositories
{
    public interface IQueryRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetAsync(Guid id);
    }
}
