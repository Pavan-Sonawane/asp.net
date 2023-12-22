using Domain.ViewModels;
using Infrastrcture.Services.CustomServices.RatingServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _ratingService.GetAllAsync();
            return Ok(ratings);
        }

        [HttpPost("addStars")]
        public async Task<IActionResult> AddStars([FromBody] RatingInsertModel model)
        {
            // Ensure that RevId is provided in the model
            if (model.RevId == 0)
            {
                return BadRequest("RevId is required.");
            }

            var result = await _ratingService.AddStarsAsync(model);
            return Ok(result);
        }
    }
}

