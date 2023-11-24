using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomServices.OrderItemServices
{
    public class OrderItemservices:IOrderItemServices
    {
        private readonly MainDbContext _context;

        public OrderItemservices(MainDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItemViewModel> GetOrderItemByIdAsync(int orderItemId)
        {
            var orderItem = await _context.OrderItems
                .Where(oi => oi.OrderItemId == orderItemId)
                .FirstOrDefaultAsync();

            return MapToViewModel(orderItem);
        }

        public async Task<List<OrderItemViewModel>> GetAllOrderItemsAsync()
        {
            var orderItems = await _context.OrderItems.ToListAsync();
            return orderItems.Select(MapToViewModel).ToList();
        }

        public async Task<int> CreateOrderItemAsync(OrderItemViewModel orderItemViewModel)
        {
            var orderItem = MapToModel(orderItemViewModel);
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();
            return orderItem.OrderItemId;
        }

        public async Task UpdateOrderItemAsync(int orderItemId, OrderItemViewModel orderItemViewModel)
        {
            var existingOrderItem = await _context.OrderItems.FindAsync(orderItemId);
            if (existingOrderItem != null)
            {
                existingOrderItem = MapToModel(orderItemViewModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderItemAsync(int orderItemId)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderItemId);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
        }

        private static OrderItemViewModel MapToViewModel(OrderItem orderItem)
        {
            return new OrderItemViewModel
            {
                OrderItemId = orderItem.OrderItemId,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice
            };
        }

        private static OrderItem MapToModel(OrderItemViewModel orderItemViewModel)
        {
            return new OrderItem
            {
                OrderItemId = orderItemViewModel.OrderItemId,
                OrderId = orderItemViewModel.OrderId,
                ProductId = orderItemViewModel.ProductId,
                Quantity = orderItemViewModel.Quantity,
                UnitPrice = orderItemViewModel.UnitPrice
            };
        }

    }
}

