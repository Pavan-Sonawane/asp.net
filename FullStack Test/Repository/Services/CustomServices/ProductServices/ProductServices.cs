/*using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomServices.ProductServices
{
    public class ProductServices:IProductServices
    {
        private readonly MainDbContext _dbContext;

        public ProductServices(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            return MapToViewModel(product);
        }

        public async Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            var products = await _dbContext.Products.ToListAsync();
            return MapListToViewModel(products);
        }

        public async Task<int> CreateProductAsync(ProductViewModel productViewModel)
        {
            var product = MapToModel(productViewModel);
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task UpdateProductAsync(int productId, ProductViewModel productViewModel)
        {
            var existingProduct = await _dbContext.Products.FindAsync(productId);
            if (existingProduct != null)
            {
                MapToModel(productViewModel, existingProduct);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        private ProductViewModel MapToViewModel(Product product)
        {
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId
                
            };
        }

        private List<ProductViewModel> MapListToViewModel(List<Product> products)
        {
            return products.Select(MapToViewModel).ToList();
        }

        private Product MapToModel(ProductViewModel productViewModel)
        {
            return new Product
            {
                ProductName = productViewModel.ProductName,
                Price = productViewModel.Price,
                StockQuantity = productViewModel.StockQuantity,
                CategoryId = productViewModel.CategoryId
            };
        }

        private void MapToModel(ProductViewModel productViewModel, Product product)
        {
            product.ProductName = productViewModel.ProductName;
            product.Price = productViewModel.Price;
            product.StockQuantity = productViewModel.StockQuantity;
            product.CategoryId = productViewModel.CategoryId;
        }
        public async Task<List<ProductViewModel>> GetProductDetailsByProductNameAsync(string productName)
        {
            var products = await _dbContext.Products
                .Where(p => p.ProductName.ToLower() == productName.ToLower())
                .Include(p => p.Category)
                .ToListAsync();

            return MapListToViewModel(products);
        }
    }
}
*/

using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Services.CustomServices.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly MainDbContext _dbContext;

        public ProductServices(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int productId)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(productId);
                return MapToViewModel(product);
            }
            catch (Exception ex)
            {
              
                throw new ApplicationException($"Error in GetProductByIdAsync: {ex.Message}", ex);
            }
        }

        public async Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            try
            {
                var products = await _dbContext.Products.ToListAsync();
                return MapListToViewModel(products);
            }
            catch (Exception ex)
            {
               
                throw new ApplicationException($"Error in GetAllProductsAsync: {ex.Message}", ex);
            }
        }

        public async Task<int> CreateProductAsync(ProductViewModel productViewModel)
        {
            try
            {
                var product = MapToModel(productViewModel);
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return product.ProductId;
            }
            catch (Exception ex)
            {
               
                throw new ApplicationException($"Error in CreateProductAsync: {ex.Message}", ex);
            }
        }

        public async Task UpdateProductAsync(int productId, ProductViewModel productViewModel)
        {
            try
            {
                var existingProduct = await _dbContext.Products.FindAsync(productId);
                if (existingProduct != null)
                {
                    MapToModel(productViewModel, existingProduct);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
               
                throw new ApplicationException($"Error in UpdateProductAsync: {ex.Message}", ex);
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(productId);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
               
                throw new ApplicationException($"Error in DeleteProductAsync: {ex.Message}", ex);
            }
        }

        public async Task<List<ProductViewModel>> GetProductDetailsByProductNameAsync(string productName)
        {
            try
            {
                var products = await _dbContext.Products
                    .Where(p => p.ProductName.ToLower() == productName.ToLower())
                    .Include(p => p.Category)
                    .ToListAsync();

                return MapListToViewModel(products);
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException($"Error in GetProductDetailsByProductNameAsync: {ex.Message}", ex);
            }
        }

        private ProductViewModel MapToViewModel(Product product)
        {
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId
            };
        }

        private List<ProductViewModel> MapListToViewModel(List<Product> products)
        {
            return products.Select(MapToViewModel).ToList();
        }

        private Product MapToModel(ProductViewModel productViewModel)
        {
            return new Product
            {
                ProductName = productViewModel.ProductName,
                Price = productViewModel.Price,
                StockQuantity = productViewModel.StockQuantity,
                CategoryId = productViewModel.CategoryId
            };
        }

        private void MapToModel(ProductViewModel productViewModel, Product product)
        {
            product.ProductName = productViewModel.ProductName;
            product.Price = productViewModel.Price;
            product.StockQuantity = productViewModel.StockQuantity;
            product.CategoryId = productViewModel.CategoryId;
        }
        public async Task<IEnumerable<Product>> GetProductsByOrderId(int orderId)
        {
            // Your logic to retrieve products by orderId
            // Example using Entity Framework:
            return await _dbContext.Products.Where(p => p.OrderItems.Any(oi => oi.OrderId == orderId)).ToListAsync();
        }
    }
}
