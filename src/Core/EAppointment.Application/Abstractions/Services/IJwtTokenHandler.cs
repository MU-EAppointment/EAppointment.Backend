using EAppointment.Domain.Entities;

namespace EAppointment.Application.Abstractions.Services
{
    public interface IJwtTokenHandler
    {
        string CreateToken(User user);
    }
}
