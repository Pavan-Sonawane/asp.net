using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.General_Services.MovieService
{
    public interface IMovieService
    {
       
            Task<IEnumerable<MovieViewModel>> GetAllAsync();
            Task<MovieViewModel> GetByIdAsync(int id);
            Task AddAsync(MovieInsertModel entity);
            Task UpdateAsync(MovieInsertModel entity);
            Task DeleteAsync(int id);
       
    }
}
