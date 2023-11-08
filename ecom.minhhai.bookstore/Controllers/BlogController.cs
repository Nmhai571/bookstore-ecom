using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace ecom.minhhai.bookstore.Controllers
{
	public class BlogController : Controller
    {
        private readonly BookStoreDbContext _context;
        public BlogController(BookStoreDbContext context)
        {
            _context = context;
        }
        [Route("blog.html")]
        public IActionResult Index(int? page = 1)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = Const.PAGE_SIZE;
            List<PostModel> listPost = new List<PostModel>();
            listPost = _context.Posts.AsNoTracking()
                    .OrderByDescending(x => x.PostId).ToList();

            PagedList<PostModel> models = new PagedList<PostModel>(listPost.AsQueryable(), pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }
        [Route("tin-tuc/{Alias}/{id}.html")]
        public async Task<IActionResult> Details(Guid? id)
        {

            var postModel = await _context.Posts
                .FirstOrDefaultAsync(x => x.PostId == id);
            if (postModel == null)
            {
                return RedirectToAction("Index");
            }
            var recentPost = _context.Posts.AsNoTracking().Where(x => x.Published == true && x.PostId != id)
                .Take(3).OrderByDescending(x => x.CreateDate).ToList();
            ViewBag.recentPost = recentPost;
			return View(postModel);
        }
    }
}   
