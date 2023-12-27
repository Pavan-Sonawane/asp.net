using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Context;
using Infrastrcture.Repository;
using Infrastrcture.Services.General_Services.MovieService;
using Microsoft.EntityFrameworkCore;

namespace Infrastrcture.Services.CustomServices.RatingServices
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> _repository;
        private readonly MainDbContext _dbContext;

        public RatingService(IRepository<Rating> repository, MainDbContext Context)
        {
            _repository = repository;
            _dbContext = Context;
        }

        public async Task<IEnumerable<RatingViewModel>> GetAllAsync()
        {
            var ratings = await _dbContext.Ratings.ToListAsync();

            foreach (var rating in ratings)
            {
                _dbContext.Entry(rating)
                    .Reference(r => r.Movie)
                .Load();

                _dbContext.Entry(rating)
                    .Reference(r => r.Reviewer)
                    .Load();
            }

            return ratings.Select(rating => new RatingViewModel
            {
                MovId = rating.MovId,
                RevId = rating.RevId,
                RevStars = rating.RevStars,
                NumOfRating = rating.NumOfRating,
                MovieName = rating.Movie != null ? rating.Movie.MovTitle : null,
                ReviewerName = rating.Reviewer != null ? rating.Reviewer.RevName : null,
            });
        }

        public async Task<float> AddStarsAsync(RatingInsertModel model)
        {
            var existingRatings = await _repository.GetAllAsync();

            var ratingsForMovie = existingRatings.Where(r => r.MovId == model.MovId).ToList();

            if (ratingsForMovie.Any())
            {
              
                var sumOfRatings = ratingsForMovie.Sum(r => r.RevStars);
                var totalRatings = ratingsForMovie.Count + 1;
                var newAverage = (sumOfRatings + model.RevStars) / totalRatings;

                foreach (var rating in ratingsForMovie)
                {
                    rating.NumOfRating = newAverage;
                    await _repository.UpdateAsync(rating);
                }

                return newAverage;
            }
            else
            {
             
                var newRating = new Rating
                {
                    MovId = model.MovId,
                    RevId = model.RevId,
                    RevStars = model.RevStars,
                    NumOfRating = model.RevStars,
                };

                await _repository.AddAsync(newRating);
                return newRating.NumOfRating;
            }
        }
    }
}

