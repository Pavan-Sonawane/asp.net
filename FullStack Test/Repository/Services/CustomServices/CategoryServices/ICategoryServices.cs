using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomServices.CategoryServices
{
    public interface ICategoryServices
    {
        Task<ICollection<CategoryViewModels>> GetAll();
        Task<CategoryViewModels> Get(int Id);
        Category GetLast();
        Task<bool> Insert(CategoryInsertModel categoryInsertModel);
        Task<bool> Update(CategoryUpdateModel categoryUpdateModel);
        Task<bool> Delete(int Id);
        Task<Category> Find(Expression<Func<Category, bool>> match);
    }
}
