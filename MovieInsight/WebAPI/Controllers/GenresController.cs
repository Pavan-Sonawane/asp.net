using Infrastrcture.Services.CustomServices.GenereService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        #region  Constructor
        private readonly IGenere _genres;

        public GenresController(IGenere genere)
        {
            _genres= genere;
        }
        #endregion

        #region GetAll 
        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genres.GetAllAsync();
            return Ok(genres);
        }

        #endregion

        #region  GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genre = await _genres.GetByIdAsync(id);

            if (genre == null)
                return NotFound($"Genere Not Found For Id {id}");

            return Ok(genre);
        }
        #endregion  
    }
}
