using Microsoft.AspNetCore.Mvc;

namespace ecom.minhhai.bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
