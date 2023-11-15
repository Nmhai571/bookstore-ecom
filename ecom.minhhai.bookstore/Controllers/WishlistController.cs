using AspNetCoreHero.ToastNotification.Abstractions;
using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.Models;
using ecom.minhhai.bookstore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ecom.minhhai.bookstore.Controllers
{
    public class WishlistController : Controller
    {
        private readonly BookStoreDbContext _context;
        public INotyfService _notyfService { get; }

        public WishlistController(BookStoreDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public List<WishlistViewModel> WishList
        {
            get
            {
                var cart = HttpContext.Session.Get<List<WishlistViewModel>>("WishList");
                if (cart == default(List<WishlistViewModel>))
                {
                    cart = new List<WishlistViewModel>(); 
                }
                return cart;
            }
        }
        [HttpGet]
        [Route("favorites.html")]
        public IActionResult Index()
        {
            return View(WishList);
        }
        [HttpPost]
        [Route("api/wish-list/add")]
        public IActionResult AddToWishList(Guid productId)
        {
            List<WishlistViewModel> lsfavoritesItem = WishList;
            try
            {
                WishlistViewModel item = WishList.SingleOrDefault(x => x.Book.BookId == productId);
                if (item != null)
                {
                    _notyfService.Warning("Added to favorites");
                }
                else
                {
                    BookModel book = _context.BookModels.SingleOrDefault(x => x.BookId == productId);
                    item = new WishlistViewModel
                    {
                        Book = book,
                    };
                    lsfavoritesItem.Add(item);
                }
                HttpContext.Session.Set<List<WishlistViewModel>>("WishList", lsfavoritesItem);
                _notyfService.Success("Wish list added successfully");
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        [Route("api/wish-list/remove")]
        public IActionResult RemoveWishListItem(Guid productId)
        {
            try
            {
                List<WishlistViewModel> lsfavoritesItem = WishList;
                WishlistViewModel item = lsfavoritesItem.SingleOrDefault(x => x.Book.BookId == productId);
                if (item != null)
                {
                    lsfavoritesItem.Remove(item);
                    _notyfService.Success("Favorites deleted successfully");
                    HttpContext.Session.Set<List<WishlistViewModel>>("WishList", lsfavoritesItem);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
            return Json(new { success = false });
        }
    }
}
