using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CinemaManagementSystem.Models;

namespace CinemaManagementSystem.Data.Services
{
    public interface IOrdersService
    {

        Task StoreOrderAsync (List<ShoppingCartItem> items, string userID, string userEmailAddress);

        Task<List<Order>> GetOrdersByUserIDAsync(string userID);
    }
}
