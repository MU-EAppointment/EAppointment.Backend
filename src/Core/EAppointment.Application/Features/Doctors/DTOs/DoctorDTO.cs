namespace EAppointment.Application.Features.Doctors.DTOs
{
    public readonly record struct DoctorDTO(Guid Id,string FirstName, string LastName, string Department, string FullName);
}
