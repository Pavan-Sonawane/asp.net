using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomServices.ProductServices
{
    public interface IProductServices
    {
        Task<ProductViewModel> GetProductByIdAsync(int productId);
        Task<List<ProductViewModel>> GetAllProductsAsync();
        Task<int> CreateProductAsync(ProductViewModel productViewModel);
        Task UpdateProductAsync(int productId, ProductViewModel productViewModel);
        Task DeleteProductAsync(int productId);
        Task<List<ProductViewModel>> GetProductDetailsByProductNameAsync(string productName);
        Task<IEnumerable<Product>> GetProductsByOrderId(int orderId);
    }
}
