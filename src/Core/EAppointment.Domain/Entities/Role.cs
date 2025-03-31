using EAppointment.Domain.Entities.Commons;
using Microsoft.AspNetCore.Identity;

namespace EAppointment.Domain.Entities
{
    public sealed class Role : IdentityRole<Guid>, IIsActive, IUpdated, ICreated
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
