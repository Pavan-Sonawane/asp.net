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
        #region Constructor
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        #endregion

        #region GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieViewModel>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(movies);
        }
        #endregion

        #region Get By ID
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieViewModel>> GetMovieById(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound($"😣 Movie Not Found For {id} Please try Using another MOvieId 😣");
            }
            return Ok(movie);
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody] MovieInsertModel movie)
        {
            await _movieService.AddAsync(movie);
            return Ok($"😎 Movie is added Successfullly 😎 ");
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(int id, [FromBody] MovieInsertModel movie)
        {
            var existingMovie = await _movieService.GetByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound("Id Not Found For the Updation");
            }

            await _movieService.UpdateAsync(movie);
            return Ok("😎 Movie Updated Successfully...😎");
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var existingMovie = await _movieService.GetByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound("😣");
            }

            await _movieService.DeleteAsync(id);
            return Ok("😎");
        }
        #endregion
    }
}

