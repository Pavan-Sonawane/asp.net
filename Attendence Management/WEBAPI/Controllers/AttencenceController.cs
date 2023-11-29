using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.CustomService.AttendenceService;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AttendanceViewModel>> GetAllAttendances()
        {
            var attendances = _attendanceService.GetAllAttendances();
            return Ok(attendances);
        }

        [HttpGet("{id}")]
        public ActionResult<AttendanceViewModel> GetAttendanceById(int id)
        {
            var attendance = _attendanceService.GetAttendanceById(id);

            if (attendance == null)
            {
                return NotFound();
            }

            return Ok(attendance);
        }

        [HttpPost("clockin/{userId}")]
        public IActionResult ClockIn(int userId)
        {
            try
            {
                _attendanceService.ClockIn(userId);
                return Ok("Clock in successful."); // or any other success message
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("applylunchbreak/{attendanceId}")]
        public IActionResult ApplyLunchBreak(int attendanceId)
        {
            _attendanceService.ApplyLunchBreak(attendanceId);
            return Ok();
        }

        [HttpPost("removelunchbreak/{attendanceId}")]
        public IActionResult RemoveLunchBreak(int attendanceId)
        {
            _attendanceService.RemoveLunchBreak(attendanceId);
            return Ok();
        }

        [HttpPost("clockout/{attendanceId}")]
        public IActionResult ClockOut(int attendanceId)
        {
            _attendanceService.ClockOut(attendanceId);
            return Ok();
        }

        [HttpGet("productivehours/{attendanceId}")]
        public ActionResult<double> GetProductiveHours(int attendanceId)
        {
            var productiveHours = _attendanceService.GetProductiveHours(attendanceId);
            return Ok(productiveHours);
        }

        [HttpGet("actualhours/{attendanceId}")]
        public ActionResult<double> GetActualHours(int attendanceId)
        {
            var actualHours = _attendanceService.GetActualHours(attendanceId);
            return Ok(actualHours);
        }
    }
}
