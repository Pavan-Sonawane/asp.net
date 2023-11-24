using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IService<Employee> _empService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController([FromForm]    IService<Employee> empservice, IWebHostEnvironment webHostEnvironment, ILogger<EmployeeController> logger)
        {
            _logger = logger;
            _empService = empservice;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var emp = _empService.GetAll();
            if (emp is not null)
            {
                return Ok(emp);
            }
            return BadRequest("Not Found");
        }

        [HttpGet("{id}")]
        public IActionResult GetEmp([FromForm]int id)
        {
            var result = _empService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult InsertUser([FromForm]Employee employee)
        {
            if (employee is not null)
            {
                _empService.Insert(employee);
                return Ok(employee);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromForm] Employee employee)
        {

            _empService.Update(employee);
            return Ok(employee);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromForm] int id)
        {
            _empService.Delete(id);
            return Ok(id);
        }
    }
}
