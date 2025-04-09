using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Application.Commons.Results;
using EAppointment.Application.Features.Doctors.DTOs;
using EAppointment.Domain.Entities;
using Mapster;
using Mediator;

namespace EAppointment.Application.Features.Doctors.Commands.Create
{
    public readonly record struct CreateDoctorCommandRequest(string FirstName, string LastName, int Department) : IRequest<Result<DoctorDTO>>;
    internal sealed class CreateDoctorCommandHandler(ICommandRepository<Doctor> _doctorCommandRepository) : IRequestHandler<CreateDoctorCommandRequest, Result<DoctorDTO>>
    {
        public async ValueTask<Result<DoctorDTO>> Handle(CreateDoctorCommandRequest request, CancellationToken cancellationToken)
        {
            Doctor? data = await _doctorCommandRepository.AddAsync(request.Adapt<Doctor>());
            await _doctorCommandRepository.SaveAsync();

            return Result<DoctorDTO>.Success(data.Adapt<DoctorDTO>());
        }
    }
}
