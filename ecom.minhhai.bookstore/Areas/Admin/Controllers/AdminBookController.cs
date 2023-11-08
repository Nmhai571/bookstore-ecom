using AspNetCoreHero.ToastNotification.Abstractions;
using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace ecom.minhhai.bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBookController : Controller
    {
        private readonly BookStoreDbContext _context;
        public INotyfService _notyfService { get; }
        public AdminBookController(BookStoreDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminBook
        public async Task<IActionResult> Index(Guid CatId, int? page = 1)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = Const.PAGE_SIZE;
            List<BookModel> listBook = new List<BookModel>();

            if (CatId != Guid.Empty)
            {
                listBook = _context.BookModels.AsNoTracking().Where(x => x.CategoryId == CatId)
                    .Include(x => x.CategoryModel).OrderByDescending(x => x.BookId).ToList();
            }
            else
            {
                listBook = _context.BookModels.AsNoTracking().Include(x => x.CategoryModel)
                    .OrderByDescending(x => x.BookId).ToList();
            }


            PagedList<BookModel> models = new PagedList<BookModel>(listBook.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentCateId = CatId;
            ViewBag.CurrentPage = pageNumber;
            ViewData["Categories"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", CatId);
            return View(models);
        }


        public IActionResult Filter(Guid CatId)
        {
            var url = $"/Admin/AdminBook";

            if (CatId != Guid.Empty)
            {
                url += $"?CatId={CatId}";
            }

            return Json(new { status = "success", redirectUrl = url });
        }

        // GET: Admin/AdminBook/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.BookModels == null)
            {
                return NotFound();
            }

            var bookModel = await _context.BookModels
                .Include(b => b.CategoryModel)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookModel == null)
            {
                return NotFound();
            }

            return View(bookModel);
        }

        // GET: Admin/AdminBook/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookName,BookDescription,Author,CategoryId,Price,Discount,Thumbnail,CreateDate,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitsInStock")] BookModel bookModel, IFormFile file)
        {

            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);
                string image = Extension.SeoURL(bookModel.BookName) + extension;
                bookModel.Thumbnail = await UploadFile.UploadFileImage(file, @"BookImage", image.ToLower());
            }
            if (string.IsNullOrEmpty(bookModel.Thumbnail))
            {
                bookModel.Thumbnail = "default-image.jpg";
            }
            bookModel.BookId = Guid.NewGuid();
            bookModel.CreateDate = DateTime.Now;
            bookModel.Alias = Extension.SeoURL(bookModel.BookName);
            _context.Add(bookModel);
            await _context.SaveChangesAsync();
            _notyfService.Success("Add New Book Successfully");
            return RedirectToAction(nameof(Index));

            // ViewData["Categories"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", bookModel.CategoryId);
            // return View(bookModel);
        }

        // GET: Admin/AdminBook/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.BookModels == null)
            {
                return NotFound();
            }

            var bookModel = await _context.BookModels.FindAsync(id);
            if (bookModel == null)
            {
                return NotFound();
            }
            ViewData["Categories"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", bookModel.CategoryId);
            return View(bookModel);
        }

        // POST: Admin/AdminBook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BookId,BookName,BookDescription,Author,CategoryId,Price,Discount,Thumbnail,CreateDate,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitsInStock")] BookModel bookModel, IFormFile file)
        {
            if (id != bookModel.BookId)
            {
                return NotFound();
            }


            try
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string image = Extension.SeoURL(bookModel.BookName) + extension;
                    bookModel.Thumbnail = await UploadFile.UploadFileImage(file, @"BookImage", image.ToLower());
                }
                if (string.IsNullOrEmpty(bookModel.Thumbnail))
                {
                    bookModel.Thumbnail = "default-image.jpg";
                }
                bookModel.Alias = Extension.SeoURL(bookModel.BookName);
                _context.Update(bookModel);
                await _context.SaveChangesAsync();
                _notyfService.Success("Update Successfully");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookModelExists(bookModel.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                
            }

            return RedirectToAction(nameof(Index));

            /*ViewData["Categories"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", bookModel.CategoryId);

            return View(bookModel);*/
        }

        // GET: Admin/AdminBook/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.BookModels == null)
            {
                return NotFound();
            }

            var bookModel = await _context.BookModels
                .Include(b => b.CategoryModel)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookModel == null)
            {
                return NotFound();
            }
            
            return View(bookModel);
        }

        // POST: Admin/AdminBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.BookModels == null)
            {
                return Problem("Entity set 'BookStoreDbContext.BookModels'  is null.");
            }
            var bookModel = await _context.BookModels.FindAsync(id);
            if (bookModel != null)
            {
                _context.BookModels.Remove(bookModel);
            }

            await _context.SaveChangesAsync();
            _notyfService.Success("Delete Successfully");
            return RedirectToAction(nameof(Index));
        }

        private bool BookModelExists(Guid id)
        {
            return (_context.BookModels?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
