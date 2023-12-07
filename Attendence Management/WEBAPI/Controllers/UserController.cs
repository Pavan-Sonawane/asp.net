using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Repository;
using Repository.Services.CustomService.UserTypeService;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UsersController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(int id, UserInsertModel userInsertModel)
        {
            try
            {
                // Define a dictionary to map user type names to UserTypeID
                var userTypeMapping = new Dictionary<string, int>
        {
            { "hr", 1 },
            { "employee", 2 }
            // Add more mappings as needed
        };

                // Convert user input to lowercase
                string userTypeLower = userInsertModel.UserTypeName.ToLower();

                // Log the user type name to check if it is correct
                Console.WriteLine($"UserTypeName: {userInsertModel.UserTypeName}");

                // Check if the user type exists in the mapping
                if (!userTypeMapping.TryGetValue(userTypeLower, out int userTypeId))
                {
                    // Handle the case where the user type does not exist in the mapping
                    ModelState.AddModelError(nameof(userInsertModel.UserTypeName), "Invalid User Type Name");
                    return BadRequest(ModelState);
                }

                // Retrieve the existing user by ID
                var existingUser = await _userRepository.Get(id);

                if (existingUser == null)
                {
                    // Handle the case where the user does not exist
                    return NotFound();
                }

                // Update User properties
                existingUser.Username = userInsertModel.Username;
                existingUser.Email = userInsertModel.Email;
                existingUser.Password = userInsertModel.Password;
                existingUser.UserTypeID = userTypeId; // Set the user type ID

                // Update the user in the repository
                await _userRepository.Update(existingUser);

                return CreatedAtAction("GetUser", new { id = existingUser.UserID }, existingUser);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                ModelState.AddModelError(string.Empty, $"An error occurred while updating the user: {ex.Message}");
                return BadRequest(ModelState);
            }
        }



        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserInsertModel userInsertModel)
        {
            try
            {
                var userTypeMapping = new Dictionary<string, int>
        {
            { "hr", 2 },
            { "employee", 1 }
        };

                string userTypeLower = userInsertModel.UserTypeName.ToLower();

                Console.WriteLine($"UserTypeName: {userInsertModel.UserTypeName}");

                if (!userTypeMapping.TryGetValue(userTypeLower, out int userTypeId))
                {
                    ModelState.AddModelError(nameof(userInsertModel.UserTypeName), "Invalid User Type Name");
                    return BadRequest(ModelState);
                }

                var newUser = new User
                {
                    Username = userInsertModel.Username,
                    Email = userInsertModel.Email,
                    Password = userInsertModel.Password,
                    UserTypeID = userTypeId 
                };

                await _userRepository.Insert(newUser);

                return CreatedAtAction("GetUser", new { id = newUser.UserID }, newUser);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while creating the user: {ex.Message}");
                return BadRequest(ModelState);
            }
        }





        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.Delete(user);

            return NoContent();
        }
    }
}