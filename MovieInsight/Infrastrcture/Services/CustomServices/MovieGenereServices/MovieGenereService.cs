using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastrcture.Context;

namespace Infrastrcture.Services.CustomServices.MovieGenereServices
{
    public class MovieGenereService : IMovieGenere
    {
        private readonly IRepository<Movie_Genres> _repository;
        private readonly MainDbContext _context;

        public MovieGenereService(IRepository<Movie_Genres> repository,MainDbContext context)
        {
            _repository = repository;
            _context= context;
        }

        public async Task<IEnumerable<Movie_Genres>> GetAllAsync()
        {
            var movieGenres = await _repository.GetAllAsync();

            foreach (var movieGenre in movieGenres)
            {
                await _context.Entry(movieGenre).Reference(mg => mg.Genres).LoadAsync();
                await _context.Entry(movieGenre).Reference(mg => mg.Movie).LoadAsync();
            }

            return movieGenres;
        }
        public async Task AddAsync(MovieGenereViewModel movieGenreViewModel)
        {
            
            var movieGenre = new Movie_Genres
            {
                MovId = movieGenreViewModel.MovId,
                GenId = movieGenreViewModel.GenId
              
            };
            await _repository.AddAsync(movieGenre);
        }
    }
}
