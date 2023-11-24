using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Repository;

namespace MovieApi.Controllers
{
    /*[EnableCors("AllowReactApp")]
    [Route("api/[controller]")]
    [ApiController]*/
    [EnableCors("AllowReactApp")]
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public IQueryable Get()
        {
            return _movieRepository.GetMovies();
        }
        [HttpPost]
        public async Task<IActionResult> Post( Movie movie)
        {
            if (movie == null)
            {
                return BadRequest(ModelState);
            }
            if (_movieRepository.MovieExists(movie.Title))
            {
                ModelState.AddModelError("", "movie already exists");
                return StatusCode(500, ModelState);
            }
            if (!_movieRepository.CreateMovie(movie))
            {
                ModelState.AddModelError("", $"Something went wrong while updating movie : {movie.Title}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Movie movie)
        {
            if (movie == null || id != movie.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_movieRepository.UpdateMovie(movie))
            {
                ModelState.AddModelError("", "Something went wrong while updating the movie");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{movieId:int}")]
        public IActionResult Delete(int movieId)
        {
            if(!_movieRepository.MovieExists(movieId))
            {
                return NotFound();
            }
            var DEL = _movieRepository.GetMovie(movieId);
            if (!_movieRepository.DeleteMovie(DEL))
            {
                ModelState.AddModelError("", $"something went wrong while deleting the movie{DEL.Title}");
                return StatusCode(500,ModelState);
            }
            return NoContent();
        }

    }
}

