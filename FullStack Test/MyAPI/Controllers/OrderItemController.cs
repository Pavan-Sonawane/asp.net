/*using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.CustomServices.OrderItemServices;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemServices _orderItemServices;

        public OrderItemController(IOrderItemServices orderItemServices)
        {
            _orderItemServices = orderItemServices;
        }

        [HttpGet("{orderItemId}")]
        public async Task<ActionResult<OrderItemViewModel>> GetOrderItemByIdAsync(int orderItemId)
        {
            var orderItem = await _orderItemServices.GetOrderItemByIdAsync(orderItemId);
            if (orderItem == null)
            {
                return NotFound($"OrderItem with ID {orderItemId} not found.");
            }
            return Ok(orderItem);
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItemViewModel>>> GetAllOrderItemsAsync()
        {
            var orderItems = await _orderItemServices.GetAllOrderItemsAsync();
            return Ok(orderItems);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrderItemAsync([FromBody] OrderItemViewModel orderItemViewModel)
        {
            var orderItemId = await _orderItemServices.CreateOrderItemAsync(orderItemViewModel);
            return CreatedAtAction(nameof(GetOrderItemByIdAsync), new { orderItemId = orderItemId }, orderItemId);
        }

        [HttpPut("{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItemAsync(int orderItemId, [FromBody] OrderItemViewModel orderItemViewModel)
        {
            await _orderItemServices.UpdateOrderItemAsync(orderItemId, orderItemViewModel);
            return NoContent();
        }

        [HttpDelete("{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItemAsync(int orderItemId)
        {
            await _orderItemServices.DeleteOrderItemAsync(orderItemId);
            return NoContent();
        }
    }
}
*/

using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.CustomServices.OrderItemServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemServices _orderItemServices;

        public OrderItemController(IOrderItemServices orderItemServices)
        {
            _orderItemServices = orderItemServices;
        }

        [HttpGet("{orderItemId}")]
        public async Task<ActionResult<OrderItemViewModel>> GetOrderItemByIdAsync(int orderItemId)
        {
            try
            {
                var orderItem = await _orderItemServices.GetOrderItemByIdAsync(orderItemId);
                if (orderItem == null)
                {
                    return NotFound($"OrderItem with ID {orderItemId} not found.");
                }
                return Ok(orderItem);
            }
            catch (Exception ex)
            {
              
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItemViewModel>>> GetAllOrderItemsAsync()
        {
            try
            {
                var orderItems = await _orderItemServices.GetAllOrderItemsAsync();
                return Ok(orderItems);
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrderItemAsync([FromBody] OrderItemViewModel orderItemViewModel)
        {
            try
            {
                var orderItemId = await _orderItemServices.CreateOrderItemAsync(orderItemViewModel);
                return CreatedAtAction(nameof(GetOrderItemByIdAsync), new { orderItemId = orderItemId }, orderItemId);
            }
            catch (Exception ex)
            {
              
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItemAsync(int orderItemId, [FromBody] OrderItemViewModel orderItemViewModel)
        {
            try
            {
                await _orderItemServices.UpdateOrderItemAsync(orderItemId, orderItemViewModel);
                return NoContent();
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItemAsync(int orderItemId)
        {
            try
            {
                await _orderItemServices.DeleteOrderItemAsync(orderItemId);
                return NoContent();
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
