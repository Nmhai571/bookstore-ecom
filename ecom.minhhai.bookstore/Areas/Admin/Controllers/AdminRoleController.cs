using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace ecom.minhhai.bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoleController : Controller
    {
        private readonly BookStoreDbContext _context;
        public INotyfService _notyfService { get; }
        public AdminRoleController(BookStoreDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminRole
        public async Task<IActionResult> Index()
        {
            return _context.Roles != null ?
                        View(await _context.Roles.ToListAsync()) :
                        Problem("Entity set 'BookStoreDbContext.Roles'  is null.");
        }

        // GET: Admin/AdminRole/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var roleModel = await _context.Roles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (roleModel == null)
            {
                return NotFound();
            }

            return View(roleModel);
        }

        // GET: Admin/AdminRole/Create  
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName")] RoleModel roleModel)
        {

            roleModel.RoleId = Guid.NewGuid();
            _context.Add(roleModel);
            await _context.SaveChangesAsync();
            _notyfService.Success("Tạo mới thành công");
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/AdminRole/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var roleModel = await _context.Roles.FindAsync(id);
            if (roleModel == null)
            {
                return NotFound();
            }
            return View(roleModel);
        }

        // POST: Admin/AdminRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RoleId,RoleName")] RoleModel roleModel)
        {
            if (id != roleModel.RoleId)
            {
                return NotFound();
            }



            try
            {
                _context.Update(roleModel);
                await _context.SaveChangesAsync();
                _notyfService.Success("Sửa thành công");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleModelExists(roleModel.RoleId))
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

        // GET: Admin/AdminRole/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var roleModel = await _context.Roles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (roleModel == null)
            {
                return NotFound();
            }

            return View(roleModel);
        }

        // POST: Admin/AdminRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Roles == null)
            {
                return Problem("Entity set 'BookStoreDbContext.Roles'  is null.");
            }
            var roleModel = await _context.Roles.FindAsync(id);
            if (roleModel != null)
            {
                _context.Roles.Remove(roleModel);
            }

            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa Thành Công");
            return RedirectToAction(nameof(Index));
        }

        private bool RoleModelExists(Guid id)
        {
            return (_context.Roles?.Any(e => e.RoleId == id)).GetValueOrDefault();
        }
    }
}
