using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ecom.minhhai.bookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookStoreDbContext _context;

        public HomeController(ILogger<HomeController> logger, BookStoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<BookModel> lsBookHomeFlag = new List<BookModel>();
            List<BookModel> lsBookBestSeller = new List<BookModel>();
            lsBookHomeFlag = _context.BookModels.AsNoTracking()
                .Where(x => x.Active == true && x.HomeFlag == true).Take(10).OrderByDescending(x => x.BookId).ToList();
            lsBookBestSeller = _context.BookModels.AsNoTracking()
                .Where(x => x.Active == true && x.BestSellers == true).Take(9).OrderByDescending(x => x.BookId).ToList();
            var lsPost = _context.Posts.AsNoTracking()
                .Where(x => x.Published == true).Take(5).OrderByDescending(x => x.CreateDate).ToList();
            ViewBag.ListPost = lsPost;
            ViewBag.ListBookBestSeller = lsBookBestSeller;
            return View(lsBookHomeFlag);
        }
        [Route("lien-he.html")]

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}