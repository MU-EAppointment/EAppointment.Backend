using EAppointment.Domain.Enums;

namespace EAppointment.Application.Features.Doctors.DTOs
{
    public readonly record  struct GetAllDoctorDTO(string FirstName, string LastName, string Department, string FullName);
}
