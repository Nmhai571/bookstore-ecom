using AspNetCoreHero.ToastNotification.Abstractions;
using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.Models;
using ecom.minhhai.bookstore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ecom.minhhai.bookstore.Controllers
{

    public class CartController : Controller
    {
        private readonly BookStoreDbContext _context;
        public INotyfService _notyfService { get; }

        public CartController(BookStoreDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [HttpGet]
        [Route("cart.html")]
        public IActionResult Index()
        {
            var lsCartItem = Cart;
            var totalQuantity = 0;
            var totalPrice = 0.0f;
            if (lsCartItem != null)
            {
                foreach (var item in lsCartItem)
                {
                    var quantity = item.Quantity;
                    var price = item.Book.Price * quantity;
                    totalQuantity += quantity;
                    totalPrice += price;
                }
            }
            ViewBag.totalQuantity = totalQuantity;
            ViewBag.totalPrice = totalPrice;
            return View(Cart);
        }

        public List<CartViewModel> Cart
        {
            get
            {
                var cart = HttpContext.Session.Get<List<CartViewModel>>("Cart");
                if (cart == default(List<CartViewModel>))
                {
                    cart = new List<CartViewModel>();
                }
                return cart;
            }
        }
        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddToCart(Guid productId, int? quantity)
        {
            List<CartViewModel> lscartItem = Cart;
            try
            {
                CartViewModel item = Cart.SingleOrDefault(x => x.Book.BookId == productId);
                if (item != null)
                {

                    foreach (var itemCart in lscartItem)
                    {
                        if (itemCart.Book.BookId == item.Book.BookId)
                        {
                            itemCart.Quantity++;
                            break;
                        }

                    }
                }
                else
                {
                    BookModel book = _context.BookModels.SingleOrDefault(x => x.BookId == productId);
                    item = new CartViewModel
                    {
                        Book = book,
                        Quantity = quantity.HasValue ? quantity.Value : 1
                    };
                    lscartItem.Add(item);
                }
                HttpContext.Session.Set<List<CartViewModel>>("Cart", lscartItem);
                _notyfService.Success("Cart added successfully");
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdateCart(Guid productId, int? quantity)
        {
            var cart = HttpContext.Session.Get<List<CartViewModel>>("Cart");
            try
            {
                if (cart != null)
                {
                    CartViewModel cartItem = cart.SingleOrDefault(x => x.Book.BookId == productId);
                    if (cartItem != null && quantity.HasValue)
                    {
                        cartItem.Quantity = quantity.Value;
                    }

                    HttpContext.Session.Set<List<CartViewModel>>("Cart", cart);
                }
                _notyfService.Success("Update Cart susessfully");
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        [Route("api/cart/remove")]
        public IActionResult RemoveCartItem(Guid productId)
        {
            try
            {
                List<CartViewModel> lscartItem = Cart;
                CartViewModel item = lscartItem.SingleOrDefault(x => x.Book.BookId == productId);
                if (item != null)
                {
                    lscartItem.Remove(item);
                }
                _notyfService.Success("Cart deleted successfully");

                HttpContext.Session.Set<List<CartViewModel>>("Cart", lscartItem);
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
