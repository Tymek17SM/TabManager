using Application.Cache;
using Application.Commands.Tab;
using Application.Queries.Tab;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [CachedReddis(600)]
        public async Task<IActionResult> GetAllAsync()
        {
            var querry = new GetAllTabQuery();
            var tabsDto = await _mediator.Send(querry);
            return Ok(tabsDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdTabQuery query)
        {
            var resulu = await _mediator.Send(query);
            return Ok(resulu);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTabAsync(CreateTabCommand command)
        {
            await _mediator.Send(command);
            return Created("sss", new object());
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
