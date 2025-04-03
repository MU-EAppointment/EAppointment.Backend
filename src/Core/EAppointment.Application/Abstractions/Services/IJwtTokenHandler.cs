using EAppointment.Domain.Entities;

namespace EAppointment.Application.Abstractions.Services
{
    public interface IJwtTokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
