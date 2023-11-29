using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.CustomService.UserTypeService;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userTypes = await _userTypeService.GetAll();
            return Ok(userTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userType = await _userTypeService.Get(id);
            if (userType != null)
            {
                return Ok(userType);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserTypeViewModel userInsertModel)
        {
            var result = await _userTypeService.Insert(userInsertModel);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserTypeViewModel userUpdateModel)
        {
            if (id != userUpdateModel.UserTypeID)
            {
                return BadRequest();
            }

            var result = await _userTypeService.Update(userUpdateModel);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userTypeService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
