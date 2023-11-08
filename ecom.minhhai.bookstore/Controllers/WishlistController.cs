using Microsoft.AspNetCore.Mvc;

namespace ecom.minhhai.bookstore.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
