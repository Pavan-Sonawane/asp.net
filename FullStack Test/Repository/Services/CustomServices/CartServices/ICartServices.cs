using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomServices.CartServices
{
    public interface ICartServices
    {
        Task<List<CartViewModels>> GetAllCartsAsync();
        Task<CartViewModels> GetCartByIdAsync(int cartId);
        Task<int> CreateCartAsync(CartViewModels cartViewModel);
        Task UpdateCartAsync(int cartId, CartViewModels cartViewModel);
        Task DeleteCartAsync(int cartId);
    }
}
