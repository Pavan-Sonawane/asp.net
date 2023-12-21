using Domain.ViewModels;
using Infrastrcture.Services.General_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorViewModel>>> GetActors()
        {
            var actors = await _actorService.GetAllAsync();
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActorViewModel>> GetActor(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        [HttpPost]
        public async Task<ActionResult> AddActor([FromBody] ActorInsertModel actorInsertModel)
        {
            await _actorService.AddAsync(actorInsertModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActor(int id, [FromBody] ActorInsertModel actorViewModel)
        {
            if (id != actorViewModel.ActId)
            {
                return BadRequest();
            }

            await _actorService.UpdateAsync(actorViewModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActor(int id)
        {
            await _actorService.DeleteAsync(id);
            return Ok();
        }
    }
}