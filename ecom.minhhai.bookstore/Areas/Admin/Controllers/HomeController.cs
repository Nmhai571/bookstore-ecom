using ecom.minhhai.bookstore.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ecom.minhhai.bookstore.Areas.Admin.Controllers
{
    [Authorize(Roles = AppicationRole.Admin)]
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
