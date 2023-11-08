using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;

namespace ecom.minhhai.bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSearchController : Controller
    {
        private readonly BookStoreDbContext _context;
        public AdminSearchController(BookStoreDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindProduct(string keyword)
        {
           List<BookModel> listProduct = new List<BookModel>();
            if(string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                listProduct = _context.BookModels.AsNoTracking().Include(x => x.CategoryModel)
                    .OrderByDescending(x => x.BookId).ToList();
                return PartialView("~/Areas/Admin/Views/Search/ListBookSearchPartialView.cshtml", listProduct);
            }
            listProduct = _context.BookModels
                .AsNoTracking()
                .Include(x => x.CategoryModel)
                .Where(x => x.BookName.Contains(keyword) || x.CategoryModel.CategoryName.Contains(keyword))
                .OrderByDescending(x => x.BookId)
                .Take(10)
                .ToList();
            if(listProduct == null)
            {
                return PartialView("~/Areas/Admin/Views/Search/ListBookSearchPartialView.cshtml", null);
            }
            else
            {
                return PartialView("~/Areas/Admin/Views/Search/ListBookSearchPartialView.cshtml", listProduct);
                /*return Json(new
                {
                    isSuccess = true,
                    html = Helper.RenderRazorView(this, "ListBookSearchPartialView", listProduct),
                });*/
            }
        }

        
    }
}
