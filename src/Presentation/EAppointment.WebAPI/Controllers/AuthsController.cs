using EAppointment.Application.Commons.Results;
using EAppointment.Application.Features.Auths.Commands.Login;
using EAppointment.Application.Features.Auths.DTOs;
using EAppointment.WebAPI.Abstractions;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace EAppointment.WebAPI.Controllers
{
    public sealed class AuthsController(IMediator _mediator) : ApiController(_mediator)
    {
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest, CancellationToken cancellationToken)
        {
            Result<LoginUserDTO> response = await _mediator.Send(loginCommandRequest, cancellationToken);
            return StatusCode((int)response.HttpStatusCode, response);
        }
    }
}
