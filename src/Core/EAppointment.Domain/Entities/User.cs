using Microsoft.AspNetCore.Identity;

namespace EAppointment.Domain.Entities
{
    public sealed class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);
    }
}
