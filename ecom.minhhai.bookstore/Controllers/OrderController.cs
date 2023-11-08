using AspNetCoreHero.ToastNotification.Abstractions;
using ecom.minhhai.bookstore.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecom.minhhai.bookstore.Controllers
{
    public class OrderController : Controller
    {
        private readonly BookStoreDbContext _context;
        public INotyfService _notyfService { get; }

        public OrderController(BookStoreDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [Route("order-details/{orderId}.html")]
        public IActionResult Index(Guid orderId)
        {
            var order = _context.Orders.AsNoTracking().Include(x => x.OrderDetailModels)
                    .ThenInclude(x => x.BookModel)
                    .Where(x => x.OrderId == orderId).SingleOrDefault();
            if(order != null)
            {
                return View(order);
            }
            return View(order);
        }
    }
}
