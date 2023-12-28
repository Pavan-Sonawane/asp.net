using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;

        public RegistrationController(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Employee
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Gender = model.Gender,
                    Name=model.Name,
                    Phone=model.Phone,
                    DOB = model.DOB,
                    DeptId=model.DeptId,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // User registered successfully
                    return Ok(new { Message = "Registration successful" });
                }
                else
                {
                    // Handle registration failure
                    return BadRequest(new { Message = "Registration failed", Errors = result.Errors });
                }
            }

            return BadRequest(ModelState);
        }
    }
}

