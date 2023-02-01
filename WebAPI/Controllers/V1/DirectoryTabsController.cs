using Application.Cache;
using Application.Commands.DirectoryTab;
using Application.Queries;
using Application.Queries.DirectoryTab;
using Application.Queries.Tab;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebAPI.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DirectoryTabsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Serilog.ILogger _logger;

        public DirectoryTabsController(IMediator mediator, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("[action]")]
        [CachedReddis(600)]
        public async Task<IActionResult> GetAllDirectoryTabs()
        {
            var querry = new GetAllDirectoryTabQuery();
            var result = await _mediator.Send(querry);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdDirectoryTabQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirectoryTab(CreateDirectoryTabCommand command)
        {
            var result = await _mediator.Send(command);
            return Created($"api/DirectoryTab/{result}", null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDirectoryTab(UpdateDirectoryTabCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleleDirectoryTab(DeleteDirectoryTabCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        //[HttpPost("[action]")]
        //public async Task<IActionResult> CreateSubordinateDirectoryTab(CreateSubordinateDirectoryTabCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Created($"api/DirectoryTab/{result}", null);
        //}

        [HttpPut("[action]")]
        public async Task<IActionResult> MoveDirectoryTab(MoveDirectoryTabCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
