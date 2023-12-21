using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Details_Card_With_Image.Models;
using Personal_Details_Card_With_Image.Models.MainDbContext;
using Personal_Details_Card_With_Image.Repositories;

namespace Personal_Details_Card_With_Image.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] UserDTO userDTO)
        {
            await _userRepository.CreateUser(userDTO);

            return CreatedAtAction(nameof(GetUserById), new { id = userDTO.Id }, userDTO);
        }

     /*   [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromForm] UserDTO userDTO)
        {
            await _userRepository.UpdateUser(id, userDTO);

            return NoContent();
        }*/


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);

            return NoContent();
        }
    }
}
