using EAppointment.Domain.Entities.Commons;

namespace EAppointment.Domain.Entities
{
    public sealed class Patient : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);
        public string IdentityNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
}
