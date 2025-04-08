using EAppointment.Application.Features.Doctors.DTOs;
using EAppointment.Domain.Entities;
using Mapster;

namespace EAppointment.Application.Features.Doctors.Mappings
{
    internal sealed class DoctorMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Doctor, GetAllDoctorDTO>()
                .Map(dest => dest.Department, src => src.Department);
        }
    }
}
