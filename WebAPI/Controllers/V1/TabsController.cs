using Application.Cache;
using Application.Commands.Tab;
using Application.Dto;
using Application.Queries.Tab;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TabsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TabsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [CachedReddis(15)]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllTabQuery query)
        {
            var tabsDto = await _mediator.Send(query);
            return Ok(new Response<IEnumerable<TabDto>>(tabsDto));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdTabQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new Response<TabDto>(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTabAsync(CreateTabCommand command)
        {
            await _mediator.Send(command);
            return Created("api/tab/id", new object());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTabAsync(UpdateTabCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTabAsync(DeleteTabCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
