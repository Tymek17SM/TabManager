using Application.Commands.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Serilog.ILogger _logger;

        public IdentityController(IMediator mediator, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            string result = await _mediator.Send(command);

            return String.IsNullOrEmpty(result) ? Unauthorized() : Ok(result);
        }
    }
}
