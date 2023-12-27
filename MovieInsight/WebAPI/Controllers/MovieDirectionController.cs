using Domain.ViewModels;
using Infrastrcture.Services.CustomServices.MovieDirectionServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDirectionController : ControllerBase
    {
        private readonly IMovieDirectionService _movieDirectionService;

        public MovieDirectionController(IMovieDirectionService movieDirectionService)
        {
            _movieDirectionService = movieDirectionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDirectionViewModel>>> GetAllMovieDirections()
        {
            var movieDirections = await _movieDirectionService.GetAllMovieDirectionsAsync();
            return Ok(movieDirections);
        }


        [HttpPost]
        public async Task<ActionResult> AddMovieDirection([FromBody] MovieDirectionViewModel movieDirectionViewModel)
        {
            if (movieDirectionViewModel == null)
                return BadRequest();

            await _movieDirectionService.AddMovieDirectionAsync(movieDirectionViewModel);

            return (Ok());
        }

       
    }
}
