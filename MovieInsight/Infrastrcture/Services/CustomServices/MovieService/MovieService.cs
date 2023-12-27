using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Repository;
using Infrastrcture.Services.General_Services.MovieService;

namespace Infrastrcture.Services.CustomServices.MovieService
{
    public class MovieService : IMovieService
    {
        #region Constructor
        private readonly IRepository<Movie> _movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
        {
            IEnumerable<Movie> movies = await _movieRepository.GetAllAsync();
            return movies.Select(movie => new MovieViewModel
            {
                MovId = movie.MovId,
                MovTitle = movie.MovTitle,
                MovYear = movie.MovYear,
                MovTime = movie.MovTime,
                MovLang = movie.MovLang,
                MovDtRel = movie.MovDtRel,
                MovRelCountry = movie.MovRelCountry,
            });
        }
        #endregion

        #region Get BY ID
        public async Task<MovieViewModel> GetByIdAsync(int id)
        {
            Movie movie = await _movieRepository.GetByIdAsync(id);
            return movie != null ? new MovieViewModel
            {
                MovId = movie.MovId,
                MovTitle = movie.MovTitle,
                MovYear = movie.MovYear,
                MovTime = movie.MovTime,
                MovLang = movie.MovLang,
                MovDtRel = movie.MovDtRel,
                MovRelCountry = movie.MovRelCountry,
            } : null;
        }
        #endregion

        #region  Post
        public async Task AddAsync(MovieInsertModel entity)
        {
            Movie movie = new()
            {
                MovTitle = entity.MovTitle,
                MovYear = entity.MovYear,
                MovTime = entity.MovTime,
                MovLang = entity.MovLang,
                MovDtRel = entity.MovDtRel,
                MovRelCountry = entity.MovRelCountry,
            };

            await _movieRepository.AddAsync(movie);
        }
        #endregion

        #region Update
        public async Task UpdateAsync(MovieInsertModel entity)
        {
            Movie movie = await _movieRepository.GetByIdAsync(entity.MovId);
            if (movie != null)
            {
                movie.MovTitle = entity.MovTitle;
                movie.MovYear = entity.MovYear;
                movie.MovTime = entity.MovTime;
                movie.MovLang = entity.MovLang;
                movie.MovDtRel = entity.MovDtRel;
                movie.MovRelCountry = entity.MovRelCountry;

                await _movieRepository.UpdateAsync(movie);
            }
        }
        #endregion

        #region Delete
        public async Task DeleteAsync(int id)
        {
            await _movieRepository.DeleteAsync(id);
        }
        #endregion
    }
}
