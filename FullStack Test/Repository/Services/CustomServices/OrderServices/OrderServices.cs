using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomServices.OrderServices
{
    public class OrderServices:IOrderServices
    {
        private readonly IRepository<Orders> _serviceCategory;
        private readonly MainDbContext _context;

        public OrderServices(IRepository<Orders> category , MainDbContext context)
        {
            _serviceCategory = category;
            _context = context;
        }

        public async Task<ICollection<OrderViewModels>> GetAll()
        {
            ICollection<OrderViewModels> categoryViewModel = new List<OrderViewModels>();
            ICollection<Orders> result = await _serviceCategory.GetAll();
            foreach (Orders category in result)
            {
                OrderViewModels categoryView = new()
                {
                    Id = category.Id,
                    OrderID= category.OrderId,
                    OrderDate = category.OrderDate,
                    TotalAmount=category.TotalAmount

                };
                categoryViewModel.Add(categoryView);
            }
            return categoryViewModel;
        }

        public async Task<OrderViewModels> Get(int Id)
        {
            var result = await _serviceCategory.Get(Id);
            if (result == null)
                return null;
            else
            {
                OrderViewModels categoryViewModel = new()
                {
                    Id = result.Id,
                    OrderID = result.OrderId,
                    OrderDate = result.OrderDate,
                    TotalAmount = result.TotalAmount

                };
                return categoryViewModel;
            }
        }

        public Orders GetLast()
        {
            return _serviceCategory.GetLast();
        }
        public Task<bool> Insert(OrderInsertModels categoryInsertModel)
        {
            Orders category = new()
            {
                OrderId = categoryInsertModel.OrderID,
                OrderDate = categoryInsertModel.OrderDate,
                TotalAmount = categoryInsertModel.TotalAmount

            };
            return _serviceCategory.Insert(category);
        }


        public async Task<bool> Update(OrderUpdateModel categoryUpdateModel)
        {
            Orders order = await _serviceCategory.Get(categoryUpdateModel.Id);
            if (order != null)
            {
                // Update the order properties
                order.OrderId = categoryUpdateModel.OrderID;
                order.OrderDate = categoryUpdateModel.OrderDate;
                order.TotalAmount = categoryUpdateModel.TotalAmount;

                // Use await if _serviceCategory.Update is asynchronous
                var result = await _serviceCategory.Update(order);

                return result; // Assuming _serviceCategory.Update returns a boolean indicating success
            }
            else
            {
                return false; // No order found with the given ID
            }
        }


        public async Task<bool> Delete(int Id)
        {
            Orders order = await _serviceCategory.Get(Id);
            if (order != null)
            {
                await _serviceCategory.Delete(order);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Task<Orders> Find(Expression<Func<Orders, bool>> match)
        {
            return _serviceCategory.Find(match);
        }
      
    }
}
