using Domain.Models;
using Domain.ViewModels;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomService.UserTypeService
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IRepository<UserType> _userTypeRepository;

        public UserTypeService(IRepository<UserType> userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<ICollection<UserTypeViewModel>> GetAll()
        {
            var userTypes = await _userTypeRepository.GetAll();
            return userTypes.Select(userType => new UserTypeViewModel
            {
                 UserTypeID= userType.UserTypeID,
                UserTypeValue = userType.UserTypeValue,
                // Map other properties directly
            }).ToList();
        }

        public async Task<UserTypeViewModel> Get(int id)
        {
            var userType = await _userTypeRepository.Get(id);
            return userType != null ? new UserTypeViewModel
            {
                UserTypeID = userType.UserTypeID,
                UserTypeValue = userType.UserTypeValue 
,
                // Map other properties directly
            } : null;
        }

        public async Task<bool> Insert(UserTypeViewModel userInsertModel)
        {
            var userType = new UserType
            {
                // Map properties directly
                UserTypeValue = userInsertModel.UserTypeValue,
                // Map other properties
            };

            return await _userTypeRepository.Insert(userType);
        }

        public async Task<bool> Update(UserTypeViewModel userUpdateModel)
        {
            var userType = await _userTypeRepository.Get(userUpdateModel.UserTypeID);

            if (userType != null)
            {
                // Map properties directly
                userType.UserTypeValue = userUpdateModel.UserTypeValue;
                // Map other properties

                return await _userTypeRepository.Update(userType);
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var userType = await _userTypeRepository.Get(id);
            if (userType != null)
            {
                return await _userTypeRepository.Delete(userType);
            }
            return false;
        }

        public async Task<UserType> Find(Expression<Func<UserType, bool>> match)
        {
            return await _userTypeRepository.Find(match);
        }
    }
}
