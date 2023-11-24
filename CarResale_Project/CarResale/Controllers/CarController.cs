using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CarResale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetAllCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddCar([FromForm] CarInsertModel carInsertModel)
        {
            var carId = await _carService.AddCarAsync(carInsertModel);
            return Ok(carId);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromForm] CarUpdateModel carUpdateModel)
        {
            if (id != carUpdateModel.Id)
            {
                return BadRequest();
            }

            await _carService.UpdateCarAsync(carUpdateModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteCarAsync(id);
            return NoContent();
        }
    }
}
