using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Context;
using Infrastrcture.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.CustomServices.MovieDirectionServices
{
    public class MovieDirectionService : IMovieDirectionService
    {
        private readonly IRepository<Movie_Direction> _movieDirectionRepository;
        private readonly MainDbContext _context;

        public MovieDirectionService(IRepository<Movie_Direction> movieDirectionRepository , MainDbContext context)
        {
            _movieDirectionRepository = movieDirectionRepository;
            _context=context;
        }

        public async Task<IEnumerable<MovieDirectionViewModel>> GetAllMovieDirectionsAsync()
        {
            var movieDirections = await _context.MovieDirection
                .Include(md => md.Director)
                .Include(md => md.Movie)
                .ToListAsync();

            return movieDirections.Select(md => new MovieDirectionViewModel
            {
                DirId = md.DirId,
                MovId = md.MovId,
                DirectorName = $"{md.Director.DirFirstName} {md.Director.DirLastName}",
                MovieTitle = md.Movie.MovTitle
            });
        }



        public async Task AddMovieDirectionAsync(MovieDirectionViewModel movieDirectionViewModel)
        {
            var movieDirection = new Movie_Direction
            {
                DirId = movieDirectionViewModel.DirId,
                MovId = movieDirectionViewModel.MovId
            };

            await _movieDirectionRepository.AddAsync(movieDirection);
        }



        
    }
}
