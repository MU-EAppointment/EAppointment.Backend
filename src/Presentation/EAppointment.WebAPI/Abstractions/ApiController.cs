using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace EAppointment.WebAPI.Abstractions
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController(IMediator mediator) : ControllerBase
    {
        public readonly IMediator _mediator = mediator;
    }
}
