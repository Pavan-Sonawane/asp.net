using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.CustomServices.MovieDirectionServices
{
    public interface IMovieDirectionService
    {
        Task<IEnumerable<MovieDirectionViewModel>> GetAllMovieDirectionsAsync();
        Task AddMovieDirectionAsync(MovieDirectionViewModel movieDirectionViewModel);
       

    }
}
