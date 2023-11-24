using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomServices.OrderServices
{
    public interface IOrderServices
    {
        Task<ICollection<OrderViewModels>> GetAll();
        Task<OrderViewModels> Get(int Id);
       
        Task<bool> Insert(OrderInsertModels categoryInsertModel);
        Task<bool> Update(OrderUpdateModel categoryUpdateModel);
        Task<bool> Delete(int Id);
        Task<Orders> Find(Expression<Func<Orders, bool>> match);
       
    }
}
