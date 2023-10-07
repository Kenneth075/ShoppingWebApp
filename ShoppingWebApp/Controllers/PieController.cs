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

        
        //public IActionResult List()
        //{
        //    PieListViewModel pieListViewModel = new PieListViewModel(_piesRepository.AllPies, "All pies");

        //    return View(pieListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Pies> pies;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _piesRepository.AllPies.OrderBy(u => u.PiesId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _piesRepository.AllPies.Where(u=>u.Category.CategoryName == category).OrderBy(u => u.PiesId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(u => u.CategoryName == category)?.CategoryName;
            }

            return View(new PieListViewModel(pies, currentCategory));
        }

        public IActionResult Details(int id)
        {
            var pie = _piesRepository.GetPieById(id);

            if(pie == null)
                return NotFound();
            return View(pie);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
