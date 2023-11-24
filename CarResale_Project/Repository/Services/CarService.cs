/*// Repository/Services/CarService.cs
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;
        private readonly MainDbContext _context;

        public CarService(IRepository<Car> carRepository ,MainDbContext context)
        {
            _carRepository = carRepository;
            _context=context;
        }
        public async Task<int> AddCarAsync(Car car)
        {
            if (car == null)
            {
                // Log the issue or throw an exception to indicate that the car object is required
                throw new ArgumentNullException(nameof(car), "Car object cannot be null");
            }

            // Save car details to the database
            var carId = await _carRepository.AddCarAsync(car);

            return carId;
        }


        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _carRepository.GetCarByIdAsync(id);
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _carRepository.GetAllCarsAsync();
        }

        public async Task UpdateCarAsync(Car car)
        {
            await _carRepository.UpdateCarAsync(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carRepository.DeleteCarAsync(id);
        }
    }
}*/
// Repository/Services/CarService.cs
using Domain.Models;
using Domain.ViewModels;
using Repository.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;

        public CarService(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<int> AddCarAsync(CarInsertModel carInsertModel)
        {
            // Map the CarInsertModel to the Car entity
            var car = new Car
            {
                Name = carInsertModel.Name,
                YearOfPurchase = carInsertModel.YearOfPurchase,
                ExpectedPrice = carInsertModel.ExpectedPrice,
                CarCompany = carInsertModel.CarCompany,
                KilometerDriven = carInsertModel.KilometerDriven,
                OwnerType = carInsertModel.OwnerType
                // Additional mappings as needed
            };

            // Save car details to the database
            var carId = await _carRepository.AddCarAsync(car);

            return carId;
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _carRepository.GetCarByIdAsync(id);
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _carRepository.GetAllCarsAsync();
        }

        public async Task UpdateCarAsync(CarUpdateModel carUpdateModel)
        {
            // Map the CarUpdateModel to the Car entity
            var car = new Car
            {
                Id = carUpdateModel.Id,
                Name = carUpdateModel.Name,
                YearOfPurchase = carUpdateModel.YearOfPurchase,
                ExpectedPrice = carUpdateModel.ExpectedPrice,
                CarCompany = carUpdateModel.CarCompany,
                KilometerDriven = carUpdateModel.KilometerDriven,
                OwnerType = carUpdateModel.OwnerType
                // Additional mappings as needed
            };

            await _carRepository.UpdateCarAsync(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carRepository.DeleteCarAsync(id);
        }
    }
}
