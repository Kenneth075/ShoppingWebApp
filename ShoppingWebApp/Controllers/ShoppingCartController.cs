using Microsoft.AspNetCore.Mvc;
using ShoppingWebApp.Models;
using ShoppingWebApp.ViewModels;

namespace ShoppingWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IPiesRepository _piesRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IPiesRepository piesRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _piesRepository = piesRepository;
        }



        public ViewResult Index()
        {
            var items = _shoppingCartRepository.GetShoppingCartItems(); //Getting all items
            _shoppingCartRepository.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCartRepository, _shoppingCartRepository.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie = _piesRepository.AllPies.FirstOrDefault(p => p.PiesId == pieId);

            if (selectedPie != null)
            {
                _shoppingCartRepository.AddToCart(selectedPie);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int pieId)
        {
            var selectedPie = _piesRepository.AllPies.FirstOrDefault(p => p.PiesId == pieId);

            if (selectedPie != null)
            {
                _shoppingCartRepository.RemoveFromCart(selectedPie);
            }

            return RedirectToAction("Index");
        }
    }
}
