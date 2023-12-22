using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.CustomServices.RatingServices
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingViewModel>> GetAllAsync();
        // Add other method declarations if needed

        Task<float> AddStarsAsync(RatingInsertModel model);
    }
}
