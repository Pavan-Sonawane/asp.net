using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomServices.CartServices
{
    public class CartServices:ICartServices
    {
        
        private readonly MainDbContext _dbContext;

        public CartServices(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CartViewModels>> GetAllCartsAsync()
        {
            var carts = await _dbContext.Carts
                .Include(c => c.Product)
                .Select(c => new CartViewModels
                {
                    CartId = c.CartId,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    // Include other properties as needed
                    ProductName = c.Product.ProductName,
                    Price = c.Product.Price
                })
                .ToListAsync();

            return carts;
        }

        public async Task<CartViewModels> GetCartByIdAsync(int cartId)
        {
            var cart = await _dbContext.Carts
                .Include(c => c.Product)
                .Where(c => c.CartId == cartId)
                .Select(c => new CartViewModels
                {
                    CartId = c.CartId,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    // Include other properties as needed
                    ProductName = c.Product.ProductName,
                    Price = c.Product.Price
                })
                .FirstOrDefaultAsync();

            return cart;
        }

        public async Task<int> CreateCartAsync(CartViewModels cartViewModel)
        {
            var cart = new Cart
            {
                ProductId = cartViewModel.ProductId,
                Quantity = cartViewModel.Quantity
            };

            _dbContext.Carts.Add(cart);
            await _dbContext.SaveChangesAsync();

            return cart.CartId;
        }

        public async Task UpdateCartAsync(int cartId, CartViewModels cartViewModel)
        {
            var cart = await _dbContext.Carts.FindAsync(cartId);

            if (cart != null)
            {
                cart.ProductId = cartViewModel.ProductId;
                cart.Quantity = cartViewModel.Quantity;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteCartAsync(int cartId)
        {
            var cart = await _dbContext.Carts.FindAsync(cartId);

            if (cart != null)
            {
                _dbContext.Carts.Remove(cart);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

