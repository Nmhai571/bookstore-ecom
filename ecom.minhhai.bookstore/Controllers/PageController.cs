using ecom.minhhai.bookstore.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecom.minhhai.bookstore.Controllers
{
	public class PageController : Controller
	{
		private readonly BookStoreDbContext _context;
        public PageController(BookStoreDbContext context)
        {
			_context = context;
        }
        [Route("page/{Alias}")]
		public async Task<IActionResult> Details(string Alias)
		{
			if (string.IsNullOrEmpty(Alias)) return RedirectToAction("Index", "Home");
			var pageModel = await _context.Pages
				.FirstOrDefaultAsync(x => x.Alias == Alias);
			if (pageModel == null)
			{
				return RedirectToAction("Index", "Home");
			}
			
			return View(pageModel);
		}
	}
}
