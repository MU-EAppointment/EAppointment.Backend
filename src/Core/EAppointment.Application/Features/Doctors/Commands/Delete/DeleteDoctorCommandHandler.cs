using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Application.Commons.Results;
using EAppointment.Application.Features.Doctors.DTOs;
using EAppointment.Domain.Entities;
using Mediator;

namespace EAppointment.Application.Features.Doctors.Commands.Delete
{
    public readonly record struct DeleteDoctorCommandRequest(Guid id) : IRequest<Result<string>>;
    internal sealed class DeleteDoctorCommandHandler(ICommandRepository<Doctor> _doctorCommandRepository) : IRequestHandler<DeleteDoctorCommandRequest, Result<string>>
    {
        public async ValueTask<Result<string>> Handle(DeleteDoctorCommandRequest request, CancellationToken cancellationToken)
        {
            await _doctorCommandRepository.DeleteAsync(request.id);
            await _doctorCommandRepository.SaveAsync();

            return Result<string>.Success("Doctor deleted successfully.");
        }
    }
}
