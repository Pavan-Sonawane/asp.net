/*using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.CustomServices.ProductServices;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _productServices.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("Get All")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productServices.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productId = await _productServices.CreateProductAsync(productViewModel);
            return CreatedAtAction(nameof(GetProductById), new { productId }, null);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productServices.UpdateProductAsync(productId, productViewModel);
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _productServices.DeleteProductAsync(productId);
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<IActionResult> GetProductDetailsByProductName([FromQuery] string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                return BadRequest("Product Name cannot be empty.");
            }

            var products = await _productServices.GetProductDetailsByProductNameAsync(productName.ToLowerInvariant());

            if (products == null || products.Count == 0)
            {
                return NotFound($"No products found with the provided Product Name: {productName}");
            }

            return Ok(products);
        }
    }
}

*/

using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.CustomServices.ProductServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            try
            {
                var product = await _productServices.GetProductByIdAsync(productId);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productServices.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductViewModel productViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var productId = await _productServices.CreateProductAsync(productViewModel);
                return CreatedAtAction(nameof(GetProductById), new { productId }, null);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductViewModel productViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _productServices.UpdateProductAsync(productId, productViewModel);
                return NoContent();
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                await _productServices.DeleteProductAsync(productId);
                return NoContent();
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetProductDetailsByProductName([FromQuery] string productName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productName))
                {
                    return BadRequest("Product Name cannot be empty.");
                }

                var products = await _productServices.GetProductDetailsByProductNameAsync(productName.ToLowerInvariant());

                if (products == null || products.Count == 0)
                {
                    return NotFound($"No products found with the provided Product Name: {productName}");
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
