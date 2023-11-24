/*using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.CustomServices.CategoryServices;
using Repository.Services.CustomServices.OrderServices;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Private Variables and Constructor
        private readonly IOrderServices _serviceCategory;
        public OrderController(IOrderServices serviceCategory) { _serviceCategory = serviceCategory; }
        #endregion

        #region Category Section
        [Route("GetAllOrders")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _serviceCategory.GetAll();
            if (result == null)
                return BadRequest("No Records Found, Please Try Again After Adding them...!");
            return Ok(result);
        }

        *//*[Route("GetOrder")]
        [HttpGet]
        public async Task<IActionResult> GetCategory(int Id)
        {
            var result = await _serviceCategory.Get(Id);
            if (result == null)
                return BadRequest("No Records Found, Please Try Again After Adding them...!");
            return Ok(result);
        }*//*

        [Route("InsertOrder")]
        [HttpPost]
        public async Task<IActionResult> InsertCategory(OrderInsertModels categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceCategory.Insert(categoryModel);
                if (result == true)
                    return Ok("Category Inserted Successfully...!");
                else
                    return BadRequest("Something Went Wrong, Category Is Not Inserted, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Category Information, Please Entering a Valid One...!");

        }

        [Route("UpdateOrder")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(OrderUpdateModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceCategory.Update(categoryModel);
                if (result == true)
                    return Ok(categoryModel);
                else
                    return BadRequest("Something Went Wrong, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Category Information, Please Entering a Valid One...!");
        }

        [Route("DeleteOrder")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var result = await _serviceCategory.Delete(Id);
            if (result == true)
                return Ok("Category Deleted SUccessfully...!");
            else
                return BadRequest("Category is not deleted, Please Try again later...!");
        }

        #endregion
    }
}
*/

using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.CustomServices.CategoryServices;
using Repository.Services.CustomServices.OrderServices;
using Repository.Services.CustomServices.ProductServices;
using System;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _serviceCategory;
        private readonly IProductServices _productService;

        public OrderController(IOrderServices serviceCategory , IProductServices productService)
        {
            _serviceCategory = serviceCategory;
            _productService = productService;
        }

        [Route("GetAllOrders")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var result = await _serviceCategory.GetAll();
                if (result == null)
                    return BadRequest("No Records Found, Please Try Again After Adding them...!");
                return Ok(result);
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [Route("InsertOrder")]
        [HttpPost]
        public async Task<IActionResult> InsertCategory(OrderInsertModels categoryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _serviceCategory.Insert(categoryModel);
                    if (result == true)
                        return Ok("Category Inserted Successfully...!");
                    else
                        return BadRequest("Something Went Wrong, Category Is Not Inserted, Please Try After Sometime...!");
                }
                else
                    return BadRequest("Invalid Category Information, Please Entering a Valid One...!");
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [Route("UpdateOrder")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(OrderUpdateModel categoryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _serviceCategory.Update(categoryModel);
                    if (result == true)
                        return Ok(categoryModel);
                    else
                        return BadRequest("Something Went Wrong, Please Try After Sometime...!");
                }
                else
                    return BadRequest("Invalid Category Information, Please Entering a Valid One...!");
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [Route("DeleteOrder")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            try
            {
                var result = await _serviceCategory.Delete(Id);
                if (result == true)
                    return Ok("Category Deleted SUccessfully...!");
                else
                    return BadRequest("Category is not deleted, Please Try again later...!");
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpGet("{orderId}/products")]
        public async Task<ActionResult<IEnumerable<string>>> GetProductsByOrderId(int orderId)
        {
            try
            {
                var order = await _serviceCategory.Get(orderId);
                if (order == null)
                {
                    return NotFound($"Order with ID {orderId} not found.");
                }

                var products = await _productService.GetProductsByOrderId(orderId);

                var productNames = products.Select(p => p.ProductName);

                return Ok(productNames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
