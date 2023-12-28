using Domain.ViewModels;
using Infrastrcture.Services.SalaryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSalaries()
        {
            var salaries = await _salaryService.GetAllSalaries();
            return Ok(salaries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalaryById(int id)
        {
            var salary = await _salaryService.GetSalaryById(id);

            if (salary == null)
                return NotFound();

            return Ok(salary);
        }

        [HttpPost]
        public async Task<IActionResult> AddSalary([FromBody] SalaryInsertModel salaryModel)
        {
            await _salaryService.AddSalary(salaryModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalary(int id, [FromBody] SalaryInsertModel salaryModel)
        {
            await _salaryService.UpdateSalary(salaryModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            await _salaryService.DeleteSalary(id);
            return Ok();
        }

        [HttpGet("salary-range")]
        public async Task<IActionResult> GetSalariesInSalaryRange([FromQuery] int minSalary, [FromQuery] int maxSalary)
        {
            var salaries = await _salaryService.GetSalariesInSalaryRange(minSalary, maxSalary);
            return Ok(salaries);
        }

        [HttpGet("department-salary")]
        public async Task<IActionResult> GetDepartmentWiseMonthlySalary([FromQuery] int departmentId, [FromQuery] int year)
        {
            var departmentMonthlySalaries = await _salaryService.GetDepartmentWiseMonthlySalary(departmentId, year);

            if (departmentMonthlySalaries == null || !departmentMonthlySalaries.Any())
            {
                return NotFound();
            }

            return Ok(departmentMonthlySalaries);
        }


    }
}

