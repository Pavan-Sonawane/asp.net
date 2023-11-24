/*using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Services.CustomServices.CartServices;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        
        private readonly ICartServices _cartServices;
        private readonly MainDbContext _context;

        public CartController( MainDbContext context, ICartServices cartServices)
        {
            _cartServices = cartServices;
            _context=context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            var carts = await _cartServices.GetAllCartsAsync();
            return Ok(carts);
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetCartById(int cartId)
        {
            var cart = await _cartServices.GetCartByIdAsync(cartId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] CartViewModels cartViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartId = await _cartServices.CreateCartAsync(cartViewModel);
            return CreatedAtAction(nameof(GetCartById), new { cartId }, null);
        }

        [HttpPut("{cartId}")]
        public async Task<IActionResult> UpdateCart(int cartId, [FromBody] CartViewModels cartViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _cartServices.UpdateCartAsync(cartId, cartViewModel);
            return NoContent();
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> DeleteCart(int cartId)
        {
            await _cartServices.DeleteCartAsync(cartId);
            return NoContent();
        }
        [HttpGet("{cartId}/category")]
        public async Task<ActionResult<string>> GetCategoryNameByCartId(int cartId)
        {
            var category = await _context.Carts
                .Where(c => c.CartId == cartId)
                .Select(c => c.Product.Category.CategoryName)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound($"Category not found for the Cart with ID {cartId}.");
            }

            return Ok(new { CategoryName = category });
        }
    }
}


*/

using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Services.CustomServices.CartServices;
using System;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;
        private readonly MainDbContext _context;

        public CartController(MainDbContext context, ICartServices cartServices)
        {
            _cartServices = cartServices;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            try
            {
                var carts = await _cartServices.GetAllCartsAsync();
                return Ok(carts);
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetCartById(int cartId)
        {
            try
            {
                var cart = await _cartServices.GetCartByIdAsync(cartId);
                if (cart == null)
                {
                    return NotFound();
                }
                return Ok(cart);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] CartViewModels cartViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var cartId = await _cartServices.CreateCartAsync(cartViewModel);
                return CreatedAtAction(nameof(GetCartById), new { cartId }, null);
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{cartId}")]
        public async Task<IActionResult> UpdateCart(int cartId, [FromBody] CartViewModels cartViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _cartServices.UpdateCartAsync(cartId, cartViewModel);
                return NoContent();
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> DeleteCart(int cartId)
        {
            try
            {
                await _cartServices.DeleteCartAsync(cartId);
                return NoContent();
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{cartId}/category")]
        public async Task<ActionResult<string>> GetCategoryNameByCartId(int cartId)
        {
            try
            {
                var category = await _context.Carts
                    .Where(c => c.CartId == cartId)
                    .Select(c => c.Product.Category.CategoryName)
                    .FirstOrDefaultAsync();

                if (category == null)
                {
                    return NotFound($"Category not found for the Cart with ID {cartId}.");
                }

                return Ok(new { CategoryName = category });
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
