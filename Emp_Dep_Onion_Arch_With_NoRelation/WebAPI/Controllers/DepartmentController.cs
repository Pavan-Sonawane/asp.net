using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IWebHostEnvironment _web;
        private readonly ILogger _logger;
        private readonly IService<department> _dep;

        public DepartmentController([FromForm] IService<department> dep, IWebHostEnvironment webHostEnvironment, ILogger<DepartmentController> logger)
        {
            _logger = logger;
            _dep = dep;
            _web = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dep = _dep.GetAll();
            if (dep != null)
            {
                return Ok(dep);
            }
            return BadRequest("Not Found");
        }
        [HttpGet("{id}")]
        public IActionResult GetDep([FromForm] int id) 
        {
            var result = _dep.Get(id);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult InsertUser([FromForm] department department)
        {
            _dep.Insert(department);
            return Ok(department);
        }
        [HttpPut]
        public IActionResult UpdateUser([FromForm] department department)
        {
            _dep.Update(department);
            return Ok(department);
        }
        [HttpDelete]
        public IActionResult DeleteUser([FromForm] int id)
        {
            _dep.Delete(id);
            return Ok(id);
        }
    }
}
