using Microsoft.AspNetCore.Mvc;
using ShoppingWebApp.Models;
using ShoppingWebApp.ViewModels;

namespace ShoppingWebApp.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartSummary(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCartRepository.GetShoppingCartItems();
            _shoppingCartRepository.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCartRepository, _shoppingCartRepository.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }
    }
}
