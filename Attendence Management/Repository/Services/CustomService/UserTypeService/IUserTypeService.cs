using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomService.UserTypeService
{
    public interface IUserTypeService
    {
        Task<ICollection<UserTypeViewModel>> GetAll();
        Task<UserTypeViewModel> Get(int Id);
        Task<bool> Insert(UserTypeViewModel userInsertModel);
        Task<bool> Update(UserTypeViewModel userUpdateModel);
        Task<bool> Delete(int Id);
        Task<UserType> Find(Expression<Func<UserType, bool>> match);
    }
}
