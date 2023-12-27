using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Context;
using Infrastrcture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastrcture.Services.CustomServices.MovieCastServices
{
    public class MovieCastService:IMovieCastService
    {
        private readonly IRepository<Movie_Cast> _movieCastRepository;
        private readonly MainDbContext _context;

        public MovieCastService(IRepository<Movie_Cast> movieCastRepository, MainDbContext context)
        {
            _movieCastRepository = movieCastRepository;
            _context= context;
        }

      public async Task<IEnumerable<MovieCastViewModel>> GetAllMovieCastsAsync()
{
    var movieCasts = await _movieCastRepository.GetAllAsync();  

    var movieCastsList = movieCasts.ToList();  

    var result = new List<MovieCastViewModel>();

    foreach (var movieCast in movieCastsList)
    {
        var actor = await _context.Actors.FindAsync(movieCast.ActId);
        var movie = await _context.Movies.FindAsync(movieCast.MovId);

        if (actor != null && movie != null)
        {
            var movieCastViewModel = new MovieCastViewModel
            {
                ActId = movieCast.ActId,
                MovId = movieCast.MovId,
                Role = movieCast.Role,
                Actor = new ActorViewModel
                {
                    ActId = actor.ActId,
                    ActFirstName = actor.ActFirstName,
                    ActLastName = actor.ActLastName,
                    ActGender = actor.ActGender,
                    ActDob = actor.ActDob
                },
                Movie = new MovieViewModel
                {
                    MovId = movie.MovId,
                    MovTitle = movie.MovTitle,
                    MovYear = movie.MovYear,
                   
                }
            };

            result.Add(movieCastViewModel);
        }
    }

    return result;
}




        public async Task<MovieCastViewModel> GetMovieCastByIdAsync(int actId, int movId)
        {
            var movieCasts = await _movieCastRepository.GetAllAsync(); 

            var movieCast = movieCasts.FirstOrDefault(mc => mc.ActId == actId && mc.MovId == movId);

            if (movieCast == null)
                return null;

            return new MovieCastViewModel
            {
                ActId = movieCast.ActId,
                MovId = movieCast.MovId,
                Role = movieCast.Role
            };
        }


        public async Task AddMovieCastAsync(MovieCastViewModel movieCastViewModel)
        {
            var movieCast = new Movie_Cast
            {
                ActId = movieCastViewModel.ActId,
                MovId = movieCastViewModel.MovId,
                Role = movieCastViewModel.Role
            };

            await _movieCastRepository.AddAsync(movieCast);
        }

        public async Task UpdateMovieCastAsync(MovieCastViewModel movieCastViewModel)
        {
            var movieCasts = await _movieCastRepository.GetAllAsync();

            var existingMovieCast = movieCasts.FirstOrDefault(mc => mc.ActId == movieCastViewModel.ActId && mc.MovId == movieCastViewModel.MovId);

            if (existingMovieCast != null)
            {
                existingMovieCast.Role = movieCastViewModel.Role;
                await _movieCastRepository.UpdateAsync(existingMovieCast);
            }
        }


        public async Task DeleteMovieCastAsync(int actId, int movId)
        {
            var movieCasts = await _movieCastRepository.GetAllAsync();

            var existingMovieCast = movieCasts.FirstOrDefault(mc => mc.ActId == actId && mc.MovId == movId);

            if (existingMovieCast != null)
            {
                await _movieCastRepository.DeleteAsync(existingMovieCast.MovId ); 
            }
        }




    }

}

