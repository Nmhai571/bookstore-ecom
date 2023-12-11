using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Models;
using ecom.minhhai.bookstore.Infrastructure;
using PagedList.Core;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ecom.minhhai.bookstore.Areas.Admin.Controllers
{
    [Authorize(Roles = AppicationRole.Admin)]
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        private readonly BookStoreDbContext _context;
        public INotyfService _notyfService { get; }

        public AdminCategoryController(BookStoreDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminCategory
        public async Task<IActionResult> Index(int? page = 1)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = Const.PAGE_SIZE;
            List<CategoryModel> listCategory = new List<CategoryModel>();
            listCategory = _context.Categories.AsNoTracking()
                    .OrderByDescending(x => x.CategoryId).ToList();

            PagedList<CategoryModel> models = new PagedList<CategoryModel>(listCategory.AsQueryable(), pageNumber, pageSize);
            //ViewBag.CurrentCateId = CatId;
            ViewBag.CurrentPage = pageNumber;
            //ViewData["Categories"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", CatId);
            return View(models);
        }

        // GET: Admin/AdminCategory/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // GET: Admin/AdminCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Ordering,Published,Title,Alias,MetaDesc,MetaKey,Cover,SchemaMarkup")] CategoryModel categoryModel)
        {
            categoryModel.Alias = Extension.SeoURL(categoryModel.CategoryName);
            categoryModel.CategoryId = Guid.NewGuid();
            _context.Add(categoryModel);
            await _context.SaveChangesAsync();
            _notyfService.Success("Create Successfully");
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/AdminCategory/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.Categories.FindAsync(id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // POST: Admin/AdminCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CategoryId,CategoryName,Ordering,Published,Title,Alias,MetaDesc,MetaKey,Cover,SchemaMarkup")] CategoryModel categoryModel)
        {
            if (id != categoryModel.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryModel);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Update Successfully");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryModelExists(categoryModel.CategoryId))
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
            return View(categoryModel);
        }

        // GET: Admin/AdminCategory/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // POST: Admin/AdminCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'BookStoreDbContext.Categories'  is null.");
            }
            var categoryModel = await _context.Categories.FindAsync(id);
            if (categoryModel != null)
            {
                _context.Categories.Remove(categoryModel);
                _notyfService.Success("Delete Successfully");
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryModelExists(Guid id)
        {
            return (_context.Categories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
