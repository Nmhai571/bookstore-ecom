using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ecom.minhhai.bookstore.Controllers.Components
{
    [ViewComponent]
    public class NumberFavoritesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var favorites = HttpContext.Session.Get<List<WishlistViewModel>>("WishList");
            return View(favorites);
        }
    }
}
