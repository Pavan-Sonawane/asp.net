using Domain.ViewModels;
using Infrastrcture.Services.General_Services.DirectorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        #region  Constructors

        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        #endregion

        #region  Get All

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorViewModel>>> GetAllDirectors()
        {
            var directors = await _directorService.GetAllAsync();
            return Ok(directors);
        }
        #endregion

        #region  Get ByID
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorViewModel>> GetDirectorById(int id)
        {
            var director = await _directorService.GetByIdAsync(id);
            if (director == null)
            {
                return NotFound("Director Not Found....😣");
            }
            return Ok(director);
        }
        #endregion

        #region Add Director
        [HttpPost]
        public async Task<ActionResult> AddDirector([FromBody] DirectorInsertModel director)
        {
            await _directorService.AddAsync(director);
            return Ok("Director added successfully....😎");
        }
        #endregion

        #region Update Director
         [HttpPut("{id}")]
         public async Task<ActionResult> UpdateDirector(int id, [FromBody] DirectorInsertModel director)
         {
            var existingDirector = await _directorService.GetByIdAsync(id);
            if (existingDirector == null)
             {
             return NotFound("😣");
             }

            await _directorService.UpdateAsync(director);
            return Ok("Director Updated Successfully...😎 ");
                    }
        #endregion


        #region  Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDirector(int id)
        {
            var existingDirector = await _directorService.GetByIdAsync(id);
            if (existingDirector == null)
            {
                return NotFound("😣");
            }

            await _directorService.DeleteAsync(id);
            return Ok("Director Deleted Successfully......😎");
        }
        #endregion

    }
}
