using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.CustomServices.ReviewerService
{
    public class ReviewerService : IReviewerService
    {
        #region  Constructor
        private readonly IRepository<Reviewer> _repository;

        public ReviewerService(IRepository<Reviewer> repository)
        {

            _repository=repository;
        }
        #endregion

        #region  Post
        public async Task AddAsync(ReviewerInsertModel entity)
        {
            var reviewer = new Reviewer
            {
                RevName = entity.RevName,
                RevDob = entity.RevDob,
                RevAddress = entity.RevAddress,
                RevCountry = entity.RevCountry,
                RevCity = entity.RevCity,
                RevPhoneNumber = entity.RevPhoneNumber,
                RevPincode = entity.RevPincode,
                RevState = entity.RevState,
            };

            await _repository.AddAsync(reviewer);
        }
        #endregion

        #region Delete

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
        #endregion

        #region Get All
        public async Task<IEnumerable<ReviewerViewModel>> GetAllAsync()
        {
            var reviewer = await _repository.GetAllAsync();
            return reviewer.Select(reviewer => new ReviewerViewModel
            {
                RevId = reviewer.RevId,
                RevName = reviewer.RevName,
                RevDob = reviewer.RevDob,
                RevAddress = reviewer.RevAddress,
                RevCountry = reviewer.RevCountry,
                RevCity = reviewer.RevCity,
                RevPhoneNumber = reviewer.RevPhoneNumber,
                RevPincode = reviewer.RevPincode,
                RevState = reviewer.RevState,
            });
        }
        #endregion

        #region Get BY Id
        public async Task<ReviewerViewModel> GetByIdAsync(int id)
        {
            var reviewer= await _repository.GetByIdAsync(id);
            return reviewer != null ? new ReviewerViewModel
            {
                RevId = reviewer.RevId,
                RevName = reviewer.RevName,
                RevDob = reviewer.RevDob,
                RevAddress = reviewer.RevAddress,
                RevCountry = reviewer.RevCountry,
                RevCity = reviewer.RevCity,
                RevPhoneNumber = reviewer.RevPhoneNumber,
                RevPincode = reviewer.RevPincode,
                RevState = reviewer.RevState,
            } : null;
        }
        #endregion 

        #region   Update   
        public async  Task UpdateAsync(ReviewerInsertModel entity)
        {
            var reviewer = await _repository.GetByIdAsync(entity.RevId);
            if (reviewer != null)
            {
                reviewer.RevName = entity.RevName;
                reviewer.RevDob= entity.RevDob;
                reviewer.RevAddress = entity.RevAddress;
                reviewer.RevCountry = entity.RevCountry;
                reviewer.RevCity = entity.RevCity;
                reviewer.RevPhoneNumber = entity.RevPhoneNumber;
                reviewer.RevPincode= entity.RevPincode;
                reviewer.RevState = entity.RevState;
            }
        }
        #endregion
    }
}
