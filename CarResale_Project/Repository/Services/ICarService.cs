// ICarService.cs
using Domain.Models;
using Domain.ViewModels;

public interface ICarService
{
    Task<int> AddCarAsync(CarInsertModel car);
    Task<Car> GetCarByIdAsync(int id);
    Task<List<Car>> GetAllCarsAsync();
    Task UpdateCarAsync(CarUpdateModel car);
    Task DeleteCarAsync(int id);
}
