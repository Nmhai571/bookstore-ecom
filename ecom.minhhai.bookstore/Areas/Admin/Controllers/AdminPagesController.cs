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
    public class AdminPagesController : Controller
    {
        private readonly BookStoreDbContext _context;
        public INotyfService _notyfService { get; }
        public AdminPagesController(BookStoreDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminPages
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = Const.PAGE_SIZE;
            var listPage = _context.Pages.AsNoTracking().OrderByDescending(x => x.PageId);

            PagedList<PageModel> models = new PagedList<PageModel>(listPage, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminPages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Pages == null)
            {
                return NotFound();
            }

            var pageModel = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (pageModel == null)
            {
                return NotFound();
            }

            return View(pageModel);
        }

        // GET: Admin/AdminPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageId,PageName,Thumbnail,Pubished,Contents,Title,MetaDesc,MetaKey,Alias,CreateDate,Ordering")] PageModel pageModel, IFormFile file)
        {
            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);
                string image = Extension.SeoURL(pageModel.PageName) + extension;
                pageModel.Thumbnail = await UploadFile.UploadFileImage(file, @"PageImage", image.ToLower());
            }
            if (string.IsNullOrEmpty(pageModel.Thumbnail))
            {
                pageModel.Thumbnail = "default-image.jpg";
            }
            pageModel.PageId = Guid.NewGuid();
            pageModel.CreateDate = DateTime.Now;
            pageModel.Alias = Extension.SeoURL(pageModel.PageName);
            _context.Add(pageModel);
            await _context.SaveChangesAsync();
            _notyfService.Success("Create Successfully");
            return RedirectToAction(nameof(Index));

        }

        // GET: Admin/AdminPages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Pages == null)
            {
                return NotFound();
            }

            var pageModel = await _context.Pages.FindAsync(id);
            if (pageModel == null)
            {
                return NotFound();
            }
            return View(pageModel);
        }

        // POST: Admin/AdminPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PageId,PageName,Thumbnail,Pubished,Contents,Title,MetaDesc,MetaKey,Alias,CreateDate,Ordering")] PageModel pageModel, IFormFile file)
        {
            if (id != pageModel.PageId)
            {
                return NotFound();
            }


            try
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string image = Extension.SeoURL(pageModel.PageName) + extension;
                    pageModel.Thumbnail = await UploadFile.UploadFileImage(file, @"PageImage", image.ToLower());
                }
                if (string.IsNullOrEmpty(pageModel.Thumbnail))
                {
                    pageModel.Thumbnail = "default-image.jpg";
                }
                pageModel.Alias = Extension.SeoURL(pageModel.PageName);
                _context.Update(pageModel);
                await _context.SaveChangesAsync();
                _notyfService.Success("Update Successfully");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageModelExists(pageModel.PageId))
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

        // GET: Admin/AdminPages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Pages == null)
            {
                return NotFound();
            }

            var pageModel = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (pageModel == null)
            {
                return NotFound();
            }

            return View(pageModel);
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
            var pageModel = await _context.Pages.FindAsync(id);
            if (pageModel != null)
            {
                _context.Pages.Remove(pageModel);
            }

            await _context.SaveChangesAsync();
            _notyfService.Success("Delete Successfully");
            return RedirectToAction(nameof(Index));
        }

        private bool PageModelExists(Guid id)
        {
            return (_context.Pages?.Any(e => e.PageId == id)).GetValueOrDefault();
        }
    }
}
