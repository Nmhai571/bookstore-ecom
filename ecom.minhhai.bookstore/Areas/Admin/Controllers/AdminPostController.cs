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
	public class AdminPostController : Controller
	{
		private readonly BookStoreDbContext _context;
		public INotyfService _notyfService { get; }

		public AdminPostController(BookStoreDbContext context, INotyfService notyfService)
		{
			_context = context;
			_notyfService = notyfService;
		}

		// GET: Admin/AdminPost
		public async Task<IActionResult> Index(int? page = 1)
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

		// GET: Admin/AdminPost/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if (id == null || _context.Posts == null)
			{
				return NotFound();
			}

			var postModel = await _context.Posts
				.FirstOrDefaultAsync(m => m.PostId == id);
			if (postModel == null)
			{
				return NotFound();
			}

			return View(postModel);
		}

		// GET: Admin/AdminPost/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Admin/AdminPost/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("PostId,Title,Contents,Thumbnail,Published,Alias,CreateDate,Author,Tags,IsHot,IsNewFeed,MetaDesc,MetaKey,View")] PostModel postModel, IFormFile file)
		{

			if (file != null)
			{
				string extension = Path.GetExtension(file.FileName);
				string image = Extension.SeoURL(postModel.Title) + extension;
				postModel.Thumbnail = await UploadFile.UploadFileImage(file, @"PostImage", image.ToLower());
			}
			if (string.IsNullOrEmpty(postModel.Thumbnail))
			{
				postModel.Thumbnail = "default-image.jpg";
			}
			postModel.Contents = postModel.Contents.Replace("<p>", "").Replace("</p>", "");
			postModel.PostId = Guid.NewGuid();
			postModel.CreateDate = DateTime.Now;
			postModel.Alias = Extension.SeoURL(postModel.Title);
			_context.Add(postModel);
			await _context.SaveChangesAsync();
			_notyfService.Success("Create Successfully");
			return RedirectToAction(nameof(Index));

			//return View(postModel);
		}

		// GET: Admin/AdminPost/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null || _context.Posts == null)
			{
				return NotFound();
			}

			var postModel = await _context.Posts.FindAsync(id);
			if (postModel == null)
			{
				return NotFound();
			}
			return View(postModel);
		}

		// POST: Admin/AdminPost/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("PostId,Title,Contents,Thumbnail,Published,Alias,CreateDate,Author,Tags,IsHot,IsNewFeed,MetaDesc,MetaKey,View")] PostModel postModel, IFormFile file)
		{
			if (id != postModel.PostId)
			{
				return NotFound();
			}


			try
			{
				if (file != null)
				{
					string extension = Path.GetExtension(file.FileName);
					string image = Extension.SeoURL(postModel.Title) + extension;
					postModel.Thumbnail = await UploadFile.UploadFileImage(file, @"PostImage", image.ToLower());
				}
				if (postModel.Thumbnail == null || postModel.Thumbnail == "")
				{
					postModel.Thumbnail = "default-image.jpg";
				}
				postModel.Alias = Extension.SeoURL(postModel.Title);
				postModel.Contents = postModel.Contents.Replace("<p>", "").Replace("</p>", "");
				_context.Update(postModel);
				await _context.SaveChangesAsync();
				_notyfService.Success("Update Successfully");
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PostModelExists(postModel.PostId))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return RedirectToAction(nameof(Index));

		}

		// GET: Admin/AdminPost/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null || _context.Posts == null)
			{
				return NotFound();
			}

			var postModel = await _context.Posts
				.FirstOrDefaultAsync(m => m.PostId == id);
			if (postModel == null)
			{
				return NotFound();
			}

			return View(postModel);
		}

		// POST: Admin/AdminPost/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			if (_context.Posts == null)
			{
				return Problem("Entity set 'BookStoreDbContext.Posts'  is null.");
			}
			var postModel = await _context.Posts.FindAsync(id);
			if (postModel != null)
			{
				_notyfService.Success("Dalete Successfully");
				_context.Posts.Remove(postModel);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PostModelExists(Guid id)
		{
			return (_context.Posts?.Any(e => e.PostId == id)).GetValueOrDefault();
		}
	}
}
