using Domain.ViewModels;
using Infrastrcture.Services.CustomServices.MovieCastServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCastController : ControllerBase
    {
        private readonly IMovieCastService _movieCastService;

        public MovieCastController(IMovieCastService movieCastService)
        {
            _movieCastService = movieCastService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieCastViewModel>>> GetAllMovieCasts()
        {
            var movieCasts = await _movieCastService.GetAllMovieCastsAsync();
            return Ok(movieCasts);
        }

        [HttpGet("{actId}/{movId}")]
        public async Task<ActionResult<MovieCastViewModel>> GetMovieCastById(int actId, int movId)
        {
            var movieCast = await _movieCastService.GetMovieCastByIdAsync(actId, movId);

            if (movieCast == null)
                return NotFound();

            return Ok(movieCast);
        }

        [HttpPost]
        public async Task<ActionResult> AddMovieCast([FromBody] MovieCastViewModel movieCastViewModel)
        {
            await _movieCastService.AddMovieCastAsync(movieCastViewModel);
            return CreatedAtAction(nameof(GetMovieCastById), new { actId = movieCastViewModel.ActId, movId = movieCastViewModel.MovId }, movieCastViewModel);
        }
        /*
                [HttpPut]
                public async Task<ActionResult> UpdateMovieCast([FromBody] MovieCastViewModel movieCastViewModel)
                {
                    await _movieCastService.UpdateMovieCastAsync(movieCastViewModel);
                    return NoContent();
                }

                [HttpDelete("{actId}/{movId}")]
                public async Task<ActionResult> DeleteMovieCast(int actId, int movId)
                {
                    await _movieCastService.DeleteMovieCastAsync(actId, movId);
                    return NoContent();
                }
            }*/
    }
}