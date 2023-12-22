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
        #region  Constructors
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }
        #endregion

        #region  Get All
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorViewModel>>> GetActors()
        {
            var actors = await _actorService.GetAllAsync();
            return Ok(actors);
        }
        #endregion

        #region  Get ByID
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorViewModel>> GetActor(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);

            if (actor == null)
            {
                return NotFound("Actor Not Found....😣 Please Try After Insertation");
            }

            return Ok(actor);
        }
        #endregion

        #region Add
        [HttpPost]
        public async Task<ActionResult> AddActor([FromBody] ActorInsertModel actorInsertModel)
        {
            await _actorService.AddAsync(actorInsertModel);
            return Ok("Actor Added Successfully.....😎");
        }
        #endregion

        #region  Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActor(int id, [FromBody] ActorInsertModel actorViewModel)
        {
            if (id != actorViewModel.ActId)
            {
                return BadRequest();
            }

            await _actorService.UpdateAsync(actorViewModel);
            return Ok("Actor Updated Successfully.......😎");
        }
        #endregion

        #region Delete 
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActor(int id)
        {
            await _actorService.DeleteAsync(id);
            return Ok("Actor Deleted Successfully......😎");
        }
        #endregion
    }
}