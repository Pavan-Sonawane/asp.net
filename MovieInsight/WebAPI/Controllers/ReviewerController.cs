using Domain.ViewModels;
using Infrastrcture.Services.CustomServices.ReviewerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        #region Constructor
        private readonly IReviewerService _reviewer;

        public ReviewerController(IReviewerService reviewerService)
        {
            _reviewer=reviewerService;
        }
        #endregion

        #region [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewerViewModel>>> GetAllDirectors()
        {
            var directors = await _reviewer.GetAllAsync();
            return Ok(directors);
        }
        #endregion

        #region getByID
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorViewModel>> GetDirectorById(int id)
        {
            var director = await _reviewer.GetByIdAsync(id);
            if (director == null)
            {
                return NotFound("Reviewer Not Found....😣");
            }
            return Ok(director);
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<IActionResult> AddReviewer([FromBody] ReviewerInsertModel reviewerModel)
        {
            try
            {
                if (reviewerModel == null)
                {
                    return BadRequest("Invalid reviewer data....😣");
                }

                await _reviewer.AddAsync(reviewerModel);

                return Ok("Reviewer added successfully.....😎");
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region  Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDirector(int id, [FromBody] ReviewerInsertModel director)
        {
            var existingDirector = await _reviewer.GetByIdAsync(id);
            if (existingDirector == null)
            {
                return NotFound("😣");
            }

            await _reviewer.UpdateAsync(director);
            return Ok("Reviewer Updated Successfully...😎 ");
        }
        #endregion

        #region  Delete 
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDirector(int id)
        {
            var existingDirector = await _reviewer.GetByIdAsync(id);
            if (existingDirector == null)
            {
                return NotFound("😣");
            }

            await _reviewer.DeleteAsync(id);
            return Ok("Reviewr Deleted Successfully......😎");
        }
        #endregion
    }
}
