using EAppointment.Application.Commons.Results;
using EAppointment.Application.Features.Auths.Commands.Login;
using EAppointment.Application.Features.Auths.DTOs;
using EAppointment.Application.Features.Doctors.Queries.GetAll;
using EAppointment.WebAPI.Abstractions;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace EAppointment.WebAPI.Controllers
{
    public sealed class DoctorsController(IMediator _mediator) : ApiController(_mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute]GetAllDoctorQueryRequest getAllDoctorQueryRequest, CancellationToken cancellationToken)
        {
            Result<List<Application.Features.Doctors.DTOs.GetAllDoctorDTO>> response = await _mediator.Send(getAllDoctorQueryRequest, cancellationToken);
            return StatusCode((int)response.HttpStatusCode, response);
        }
    }
}
