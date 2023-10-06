using Microsoft.AspNetCore.Mvc;
using ShoppingWebApp.Models;
using ShoppingWebApp.ViewModels;

namespace ShoppingWebApp.Controllers
{
    public class PieController : Controller
    {
        private readonly IPiesRepository _piesRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPiesRepository piesRepository, ICategoryRepository categoryRepository)
        {
            _piesRepository = piesRepository;
            _categoryRepository = categoryRepository;
        }

        
        public IActionResult List()
        {
            PieListViewModel pieListViewModel = new PieListViewModel(_piesRepository.AllPies, "All pies");

            return View(pieListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _piesRepository.GetPieById(id);

            if(pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
