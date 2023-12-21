using Domain.ViewModels;
using Infrastrcture.Services.General_Services.MovieService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieViewModel>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieViewModel>> GetMovieById(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody] MovieInsertModel movie)
        {
            await _movieService.AddAsync(movie);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(int id, [FromBody] MovieInsertModel movie)
        {
            var existingMovie = await _movieService.GetByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            await _movieService.UpdateAsync(movie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var existingMovie = await _movieService.GetByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            await _movieService.DeleteAsync(id);
            return Ok();
        }
    }
}

