using Application.Commands.DirectoryTab;
using Application.Queries;
using Application.Queries.DirectoryTab;
using Application.Queries.Tab;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectoryTabController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DirectoryTabController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
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
    }
}
