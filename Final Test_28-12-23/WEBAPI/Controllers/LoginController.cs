/*using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LoginController> _logger;

        public LoginController(SignInManager<User> signInManager, ILogger<LoginController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation("Attempting to log in user: {0}", model.Email);
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("Login successful for user: {0}", model.Email);
                        return Ok(new { Message = "Login successful" });
                    }
                    else
                    {
                        _logger.LogError("Login failed for user: {0}. Error: {1}", model.Email, result.ToString());
                        return Unauthorized(new { Message = "Invalid login attempt" });
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("An error occurred during login: {0}", ex.ToString());
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Internal Server Error" });
                }
            }

            return BadRequest(ModelState);
        }

    }

}*/