using Microsoft.AspNetCore.Mvc;

namespace ecom.minhhai.bookstore.Controllers
{
    public class AjaxContentController : Controller
    {
        public IActionResult NumberCart()
        {
            return ViewComponent("NumberCart");
        }
    }
}
