using EAppointment.Domain.Enums;

namespace EAppointment.Domain.Entities
{
    public class Doctor
    {
        public Doctor() => Id = Guid.NewGuid();

        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DepartmentEnum Department { get; set; } = DepartmentEnum.Default;
        public string FullName => string.Join(" ", FirstName, LastName);
    }
}
