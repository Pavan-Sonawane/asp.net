using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IRepository<T>
    {
        Task<int> AddCarAsync(Car car);
        Task<Car> GetCarByIdAsync(int id);
        Task<List<Car>> GetAllCarsAsync();
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int id);
    }
}
