using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CinemaManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext _context;

        public OrdersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIDAsync(string userID)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Where(n => n.UserId == userID).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userID, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userID,
                Email = userEmailAddress
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach(var item in items)
            {
                var OrderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                await _context.OrderItems.AddAsync(OrderItem); 
            }

            await _context.SaveChangesAsync();
            
        }
    }
}
