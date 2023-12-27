using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.CustomServices.MovieCastServices
{
    public interface IMovieCastService
    {
        Task<IEnumerable<MovieCastViewModel>> GetAllMovieCastsAsync();
        Task<MovieCastViewModel> GetMovieCastByIdAsync(int actId, int movId);
        Task AddMovieCastAsync(MovieCastViewModel movieCastViewModel);
        Task UpdateMovieCastAsync(MovieCastViewModel movieCastViewModel);
        Task DeleteMovieCastAsync(int actId, int movId);
    }
}

