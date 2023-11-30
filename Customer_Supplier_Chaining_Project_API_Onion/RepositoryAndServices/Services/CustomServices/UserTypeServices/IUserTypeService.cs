using Domain.Models;
using Domain.ViewModels;
using System.Linq.Expressions;

namespace RepositoryAndServices.Services.CustomServices.UserTypeServices
{
    public interface IUserTypeService
    {
        Task<ICollection<UserTypeViewModel>> GetAll();
        Task<UserTypeViewModel> Get(int Id);
        Task<bool> Insert(UserTypeInsertModel userInsertModel);
        Task<bool> Update(UserTypeUpdateModel userUpdateModel);
        Task<bool> Delete(int Id);
        Task<UserType> Find(Expression<Func<UserType, bool>> match);
    }
}
