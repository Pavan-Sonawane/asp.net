using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.CustomServices.MovieGenereServices
{
    public interface IMovieGenere
    {
        Task<IEnumerable<Movie_Genres>> GetAllAsync();
        Task AddAsync(MovieGenereViewModel movieGenre);
    }
}
