using Application.Abstractions.Services;
using Application.Models.Harbour;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HarboursController : Controller
    {
        private readonly IHarbourService _HarbourService;

        public HarboursController(IHarbourService HarbourService)
        {
            _HarbourService = HarbourService;
        }

        [HttpGet]
        public async Task<ActionResult> GetHarbours(CancellationToken cancellationToken)
        {
            var harbours = await _HarbourService.GetAll(cancellationToken);

            return Ok(harbours);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHarbour(Guid id, CancellationToken cancellationToken)
        {
            var harbour = await _HarbourService.GetHarbourById(id, cancellationToken);

            return Ok(harbour);
        }

        [HttpPost]
        public async Task<ActionResult> AddHarbour(CreateHarbour harbour, CancellationToken cancellationToken)
        {
            var result = await _HarbourService.AddHarbour(harbour, cancellationToken);

           return Created(result.ToString(), null);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHarbour(UpdateHarbour harbour, CancellationToken cancellationToken)
        {
            var result = await _HarbourService.UpdateHarbour(harbour, cancellationToken);

            return Ok(result.ToString());
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHarbour(Guid id, CancellationToken cancellationToken)
        {
            await _HarbourService.RemoveHarbour(id, cancellationToken);

            return NoContent();
        }

    }
}
