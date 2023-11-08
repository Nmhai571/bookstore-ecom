using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ecom.minhhai.bookstore.Controllers.Components
{
    [ViewComponent]
    public class NumberCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartViewModel>>("Cart");
            return View(cart);
        }
    }
}
