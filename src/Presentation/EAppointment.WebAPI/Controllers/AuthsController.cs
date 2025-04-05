using EAppointment.Application.Commons.Results;
using EAppointment.Application.Features.Auths.Commands.Login;
using EAppointment.Application.Features.Auths.DTOs;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace EAppointment.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class AuthsController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest, CancellationToken cancellationToken)
        {
            Result<LoginUserDTO> response = await _mediator.Send(loginCommandRequest, cancellationToken);
            return StatusCode((int)response.HttpStatusCode, response);
        }
    }
}
