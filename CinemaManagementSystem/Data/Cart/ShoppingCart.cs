using CinemaManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Data.Cart
{
    public class ShoppingCart
    {
        public ApplicationDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set;}
        
        public ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId ==
            ShoppingCartId).Include(n => n.Movie).ToList());
        }
        public double GetShoppingCartTotal() =>_context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n =>
            n.Movie.Price * n.Amount).Sum();
            
        }
}

