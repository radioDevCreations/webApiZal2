using Application.Abstractions.Services;
using Application.Models.Boat;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoatsController : Controller
    {
        private readonly IBoatService _BoatService;

        public BoatsController(IBoatService BoatService)
        {
            _BoatService = BoatService;
        }

        [HttpGet]
        public async Task<ActionResult> GetBoat(CancellationToken cancellationToken)
        {
            var boat = await _BoatService.GetAll(cancellationToken);

            return Ok(boat);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBoat(Guid id, CancellationToken cancellationToken)
        {
            var boat = await _BoatService.GetBoatById(id, cancellationToken);

            return Ok(boat);
        }

        [HttpPost]
        public async Task<ActionResult> AddBoat(CreateBoat boat, CancellationToken cancellationToken)
        {
            var result = await _BoatService.AddBoat(boat, cancellationToken);

            return Created(result.ToString(), null);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBoat(UpdateBoat boat, CancellationToken cancellationToken)
        {
            var result = await _BoatService.UpdateBoat(boat, cancellationToken);

            return Ok(result.ToString());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBoat(Guid id, CancellationToken cancellationToken)
        {
            await _BoatService.RemoveBoat(id, cancellationToken);

            return NoContent();
        }

    }
}
