using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Context;
using Infrastrcture.Services.CustomServices.MovieGenereServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenereController : ControllerBase
    {
        private readonly IMovieGenere _movieGenreService;
        private readonly MainDbContext _context;

        public MovieGenereController(IMovieGenere movieGenreService,MainDbContext context)
        {
            _movieGenreService = movieGenreService;
            _context= context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie_Genres>>> GetAllAsync()
        {
            var movieGenres = await _movieGenreService.GetAllAsync();

            foreach (var movieGenre in movieGenres)
            {
                await _context.Entry(movieGenre).Reference(mg => mg.Genres).LoadAsync();
                await _context.Entry(movieGenre).Reference(mg => mg.Movie).LoadAsync();
            }

            return Ok(movieGenres);
        }
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] MovieGenereViewModel movieGenreViewModel)
        {
            await _movieGenreService.AddAsync(movieGenreViewModel);
            return Ok("Movie Genre Added Successfully....!");
        }

    }
}
