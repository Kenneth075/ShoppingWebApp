using Microsoft.AspNetCore.Mvc;
using ShoppingWebApp.Models;
using ShoppingWebApp.ViewModels;

namespace ShoppingWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPiesRepository _piesRepository;

        public HomeController(IPiesRepository piesRepository)
        {
            _piesRepository = piesRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel(_piesRepository.PiesOfTheWeek);
            return View(homeViewModel);
        }
    }
}
