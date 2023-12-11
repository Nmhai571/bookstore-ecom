using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.Models;
using ecom.minhhai.bookstore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace ecom.minhhai.bookstore.Controllers
{
    public class ProductController : Controller
    {
        private readonly BookStoreDbContext _context;

        public ProductController(BookStoreDbContext context)
        {
            _context = context;
        }
        [Route("shop.html")]
        public IActionResult Index(int? page)
        {
            int allBook = 0;
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var category = _context.Categories.Include(x => x.BookModels);
                List<CategoryViewModel> lsCatModel = new List<CategoryViewModel>();
                foreach (var item in category)
                {
                    var viewModel = new CategoryViewModel
                    {
                        CategoryId = item.CategoryId,
                        CategoryName = item.CategoryName,
                        NumberOfBook = item.BookModels.Count()
                    };
                    lsCatModel.Add(viewModel);
                    allBook += item.BookModels.Count();

                }
                
                var pageSize = Const.PAGE_SIZE;
                List<BookModel> listProduct = new List<BookModel>();
                listProduct = _context.BookModels.AsNoTracking().Include(x => x.CategoryModel)
                        .OrderByDescending(x => x.BookId).ToList();

                PagedList<BookModel> models = new PagedList<BookModel>(listProduct.AsQueryable(), pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                ViewBag.Category = lsCatModel;
                ViewBag.AllBook = allBook;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult ListProductByCategory(Guid categoryId, int? page = 1)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = Const.PAGE_SIZE;
                var category = _context.Categories.Find(categoryId);
                List<BookModel> listProduct = new List<BookModel>();
                if(categoryId == Guid.Empty)
                {
                    listProduct = _context.BookModels.AsNoTracking().Include(x => x.CategoryModel)
                        .OrderByDescending(x => x.BookId).ToList();
                }
                else
                {
                    listProduct = _context.BookModels.AsNoTracking().Include(x => x.CategoryModel)
                    .Where(x => x.CategoryId == categoryId)
                        .OrderByDescending(x => x.BookId).ToList();
                }


                PagedList<BookModel> models = new PagedList<BookModel>(listProduct.AsQueryable(), pageNumber, pageSize);
                ViewBag.CatId = categoryId;
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCategory = category;
                return PartialView("ProductsByCategoryPartialView", models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        
        }
        [Route("product/{Alias}/{id}.html")]
        public IActionResult Details(Guid id)
        {
            try
            {
                var book = _context.BookModels.Include(x => x.CategoryModel).FirstOrDefault(x => x.BookId == id);
                if (book == null)
                {
                    return RedirectToAction("Index");
                }
                var relatedProducts = _context.BookModels.AsNoTracking()
                    .Include(x => x.CategoryModel)
                    .Where(x => x.CategoryId == book.CategoryId && x.BookId != id && x.Active == true)
                    .OrderByDescending(x => x.BookId)
                    .Take(4).ToList();
                ViewBag.RelatedProducts = relatedProducts;
                return View(book);
            }
            catch
            {
                return RedirectToAction("Index", "Home");

            }
        }

        [HttpGet]
        //[Route("product/{keyword}.html")]
        public IActionResult SearchProduct(string keyword)
        {
            List<BookModel> listProduct = new List<BookModel>();
            
            listProduct = _context.BookModels
                .AsNoTracking()
                .Include(x => x.CategoryModel)
                .Where(x => x.BookName.Contains(keyword) || x.CategoryModel.CategoryName.Contains(keyword))
                .OrderByDescending(x => x.BookId)
                .Take(10)
                .ToList();
            if (listProduct == null)
            {
                return View();
            }
            else
            {
                return View(listProduct);
            }
        }
    }
}
