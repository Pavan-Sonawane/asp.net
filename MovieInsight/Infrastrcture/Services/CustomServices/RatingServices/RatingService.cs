using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Repository;
using Infrastrcture.Services.General_Services.MovieService;

namespace Infrastrcture.Services.CustomServices.RatingServices
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> _repository;

        public RatingService(IRepository<Rating> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RatingViewModel>> GetAllAsync()
        {
            var ratings = await _repository.GetAllAsync();
            return ratings.Select(rating => new RatingViewModel
            {
                MovId = rating.MovId,
                RevId = rating.RevId,
                RevStars = rating.RevStars,
                NumOfRating = rating.NumOfRating,
                Movie = rating.Movie,
                Reviewer = rating.Reviewer,
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

