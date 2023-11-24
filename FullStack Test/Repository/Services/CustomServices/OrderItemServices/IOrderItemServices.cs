using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomServices.OrderItemServices
{
    public interface IOrderItemServices
    {
        Task<OrderItemViewModel> GetOrderItemByIdAsync(int orderItemId);
        Task<List<OrderItemViewModel>> GetAllOrderItemsAsync();
        Task<int> CreateOrderItemAsync(OrderItemViewModel orderItemViewModel);
        Task UpdateOrderItemAsync(int orderItemId, OrderItemViewModel orderItemViewModel);
        Task DeleteOrderItemAsync(int orderItemId);
        
    }
}
