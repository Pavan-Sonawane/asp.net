using Domain.Models;
using Infrastrcture.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly MainDbContext _context;

        public SearchController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> SearchMovies(string query)
        {
            var movies = await _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Directors)
                .Include(m => m.Cast)
                    .ThenInclude(mc => mc.Actor)
                .Where(m =>
                    m.MovTitle.Contains(query) ||
                    m.Directors.Any(d => (d.Director.DirFirstName + " " + d.Director.DirLastName).Contains(query)) ||
                    m.Cast.Any(mc => (mc.Actor.ActFirstName + " " + mc.Actor.ActLastName).Contains(query)) ||
                    m.Genres.Any(g => g.Genres.GenTitle.Contains(query))
                )
                .ToListAsync();

            return movies;
        }
    }




}
