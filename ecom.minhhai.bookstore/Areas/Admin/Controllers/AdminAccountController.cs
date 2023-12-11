using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ecom.minhhai.bookstore.Areas.Admin.Controllers
{
    /*[Area("Admin")]
    public class AdminAccountController : Controller
    {
        private readonly BookStoreDbContext _context;
        private readonly UserManager<AccountModel> _userManager;

        public AdminAccountController(BookStoreDbContext context, UserManager<AccountModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin/AdminAccount
        public async Task<IActionResult> Index()
        {
            ViewData["RoleName"] = new SelectList(_context.Roles, "RoleId", "RoleName");

            List<SelectListItem> listStatus = new List<SelectListItem>();
            listStatus.Add(new SelectListItem() { Text = "Active", Value = "1" });
            listStatus.Add(new SelectListItem() { Text = "Block", Value = "0" });
            ViewData["listStatus"] = listStatus;

            var bookStoreDbContext = _context.Include(a => a.RoleModel);
            return View(await bookStoreDbContext.ToListAsync());
        }

        // GET: Admin/AdminAccount/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var accountModel = await _context.Accounts
                .Include(a => a.RoleModel)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (accountModel == null)
            {
                return NotFound();
            }

            return View(accountModel);
        }

        // GET: Admin/AdminAccount/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId");
            return View();
        }

        // POST: Admin/AdminAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,Phone,Email,Password,Salt,Active,FullName,Thumbnail,RoleId,Lastlogin,CreateDate")] AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                accountModel.AccountId = Guid.NewGuid();
                _context.Add(accountModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", accountModel.RoleId);
            return View(accountModel);
        }

        // GET: Admin/AdminAccount/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var accountModel = await _context.Accounts.FindAsync(id);
            if (accountModel == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", accountModel.RoleId);
            return View(accountModel);
        }

        // POST: Admin/AdminAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AccountId,Phone,Email,Password,Salt,Active,FullName,Thumbnail,RoleId,Lastlogin,CreateDate")] AccountModel accountModel)
        {
            if (id != accountModel.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountModelExists(accountModel.AccountId))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", accountModel.RoleId);
            return View(accountModel);
        }

        // GET: Admin/AdminAccount/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var accountModel = await _context.Accounts
                .Include(a => a.RoleModel)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (accountModel == null)
            {
                return NotFound();
            }

            return View(accountModel);
        }

        // POST: Admin/AdminAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'BookStoreDbContext.Accounts'  is null.");
            }
            var accountModel = await _context.Accounts.FindAsync(id);
            if (accountModel != null)
            {
                _context.Accounts.Remove(accountModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountModelExists(Guid id)
        {
            return (_context.Accounts?.Any(e => e.AccountId == id)).GetValueOrDefault();
        }
    }*/
}
