using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.CustomServices.ReviewerService
{
    public interface IReviewerService
    {
        Task<IEnumerable<ReviewerViewModel>> GetAllAsync();
        Task<ReviewerViewModel> GetByIdAsync(int id);
        Task AddAsync(ReviewerInsertModel entity);
        Task UpdateAsync(ReviewerInsertModel entity);
        Task DeleteAsync(int id);
    }
}
