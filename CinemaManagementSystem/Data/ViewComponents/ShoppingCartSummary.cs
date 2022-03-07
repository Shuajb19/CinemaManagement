using CinemaManagementSystem.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.Data.ViewComponents
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}
