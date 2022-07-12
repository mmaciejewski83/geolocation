using Geolocation.Application.CQRS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Geolocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLocation command,
            [FromServices] ICommandHandler<CreateLocation> commandHandler)
        {
            await commandHandler.HandleAsync(command);
            return Created($"locations/{command.Id}", command.Id);
        }

        [HttpDelete]
        [Route("{locationId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid locationId,
            [FromServices] ICommandHandler<DeleteLocation> commandHandler)
        {
            await commandHandler.HandleAsync(new DeleteLocation(locationId));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetALl([FromServices] IQueryHandler<GetLocationsQuery, GetLocationsQueryResponse> queryHandler)
        {
            var result = await queryHandler.QueryAsync(new GetLocationsQuery());
            return Ok(result);
        }
    }
}
