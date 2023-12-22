using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.CustomServices.GenereService
{
    public interface IGenere
    {
        Task<IEnumerable<Genres>> GetAllAsync();
        Task<Genres> GetByIdAsync(int id);
    }
}
