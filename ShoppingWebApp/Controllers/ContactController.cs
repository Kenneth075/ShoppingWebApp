using Microsoft.AspNetCore.Mvc;

namespace ShoppingWebApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
