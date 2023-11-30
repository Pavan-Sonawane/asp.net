using Domain.Models;
using Domain.ViewModels;
using System.Linq.Expressions;
using RepositoryAndServices.Repository;

namespace RepositoryAndServices.Services.CustomServices.UserTypeServices
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IRepository<UserType> _userType;
        private readonly IRepository<UserType> _userTypeRepository;

        public UserTypeService(IRepository<UserType> userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<ICollection<UserTypeViewModel>> GetAll()
        {
            var userTypes = await _userTypeRepository.GetAll();
            return userTypes.Select(MapToViewModel).ToList();
        }

        public async Task<UserTypeViewModel> Get(Guid id)
        {
            var userType = await _userTypeRepository.Find(x => x.Id == id);
            return userType != null ? MapToViewModel(userType) : null;
        }

        public async Task<bool> Insert(UserTypeInsertModel userInsertModel)
        {
            var userType = MapToModel(userInsertModel);
            return await _userTypeRepository.Insert(userType);
        }

        public async Task<bool> Update(UserTypeUpdateModel userUpdateModel)
        {
            var userType = MapToModel(userUpdateModel);
            return await _userTypeRepository.Update(userType);
        }

        public async Task<bool> Delete(Guid id)
        {
            var userType = await _userTypeRepository.Find(x => x.Id == id);
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

        // Helper methods for mapping between ViewModel and Entity
        private UserTypeViewModel MapToViewModel(UserType userType)
        {
            // Implement mapping logic from UserType to UserTypeViewModel
            // For simplicity, you can use tools like AutoMapper for mapping
            // or manually map the properties.
        }

        private UserType MapToModel(UserTypeInsertModel userInsertModel)
        {
            // Implement mapping logic from UserTypeInsertModel to UserType
            // For simplicity, you can use tools like AutoMapper for mapping
            // or manually map the properties.
        }

        private UserType MapToModel(UserTypeUpdateModel userUpdateModel)
        {
            // Implement mapping logic from UserTypeUpdateModel to UserType
            // For simplicity, you can use tools like AutoMapper for mapping
            // or manually map the properties.
        }
    }
}
