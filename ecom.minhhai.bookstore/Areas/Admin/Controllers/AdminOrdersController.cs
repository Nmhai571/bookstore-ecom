using AspNetCoreHero.ToastNotification.Abstractions;
using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Data;

namespace ecom.minhhai.bookstore.Areas.Admin.Controllers
{
    [Authorize(Roles = AppicationRole.Admin)]
    [Area("Admin")]
    public class AdminOrdersController : Controller
    {
        
        private readonly BookStoreDbContext _context;
        public INotyfService _notyfService { get; }
        public AdminOrdersController(BookStoreDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = Const.PAGE_SIZE;
            var listPage = _context.Orders.AsNoTracking()
                .Include(x => x.TransactStatusModel)
                .Include(x => x.AccountModel)
                .OrderByDescending(x => x.OrderDate);
            var TotalPriceAllOrder = 0.0f;
            foreach (var item in _context.Orders)
            {
                TotalPriceAllOrder += (float)item.TotalPrice;
            }
            ViewBag.TotalPriceAllOrder = TotalPriceAllOrder;    

            PagedList<OrderModel> models = new PagedList<OrderModel>(listPage, pageNumber, pageSize);
            return View(models);
        }
        public IActionResult Details(Guid? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orderModel =  _context.Orders
                .Include(x => x.OrderDetailModels)
                .ThenInclude(x => x.BookModel)
                .SingleOrDefault(m => m.OrderId == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // POST: Admin/AdminPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Pages == null)
            {
                return Problem("Entity set 'BookStoreDbContext.Pages'  is null.");
            }
            var orderModel = await _context.Orders.FindAsync(id);
            if (orderModel != null)
            {
                _context.Orders.Remove(orderModel);
            }

            await _context.SaveChangesAsync();
            _notyfService.Success("Delete Successfully");
            return RedirectToAction(nameof(Index));
        }
    }
}
