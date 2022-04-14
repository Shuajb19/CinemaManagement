using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CinemaManagementSystem.Data.Cart;
using CinemaManagementSystem.Data.Services;
using CinemaManagementSystem.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using CinemaManagementSystem.Models;

namespace CinemaManagementSystem.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            
            return View(response);
        }
        public IActionResult ShoppingCart2(Coupon coupon)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            var couponitems = coupon.Coupons_Movies;

            _shoppingCart.ShoppingCartItems = metoda(items,couponitems);

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };  

            return View(response);
        }

        public List<ShoppingCartItem> metoda(List<ShoppingCartItem> shoppingCartItems, List<Coupon_Movie> movies)
        {
            foreach (var item in shoppingCartItems)
            {
                foreach (var item2 in movies)
                {
                    if (item.Movie.Id == item2.Movie.Id)
                    {
                        item.Movie.Price = item2.Coupon.Discount;
                    }
                }
            }
            return shoppingCartItems;
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var userRoleIsAdmin = User.IsInRole("Admin");
            if (!userRoleIsAdmin)
            {
                var item = await _moviesService.GetMovieByIdAsync(id);

                if (item != null)
                {
                    _shoppingCart.AddItemToCart(item);
                }
                return RedirectToAction(nameof(ShoppingCart));

            }
            return NotFound();
        }
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            if (items.Count > 0)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string userEmailAddress = User.FindFirstValue(ClaimTypes.Email); 

                await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
                await _shoppingCart.ClearShoppingCartAsync();

                return View("OrderCompleted");

            }
            return View("Error");
        }
    }
}
