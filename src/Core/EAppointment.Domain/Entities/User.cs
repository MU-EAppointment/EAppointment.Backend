using EAppointment.Domain.Entities.Commons;
using Microsoft.AspNetCore.Identity;

namespace EAppointment.Domain.Entities
{
    public sealed class User : IdentityUser<Guid>, IIsActive, IUpdated, ICreated
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}