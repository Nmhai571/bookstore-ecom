using AspNetCoreHero.ToastNotification.Abstractions;
using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.Models;
using ecom.minhhai.bookstore.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ecom.minhhai.bookstore.Controllers
{
    public class AccountController : Controller
    {
        private readonly BookStoreDbContext _context;
        public INotyfService _notyfService { get; }

        public AccountController(BookStoreDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [Route("my-account.html")]
        public IActionResult Dashboard()
        {
            var accountId = Request.Cookies["User"];
            var account = _context.Accounts.SingleOrDefault(x => x.AccountId.ToString() == accountId);
            if (account != null)
            {
                var lsOrder = _context.Orders.AsNoTracking().Include(x => x.OrderDetailModels)
                    .ThenInclude(x => x.BookModel)
                    .Where(x => x.AccountId == account.AccountId).OrderByDescending(x => x.OrderDate).ToList();
                ViewBag.ListOrder = lsOrder;
            }
            return View(account);
        }
        [HttpGet]
        [AllowAnonymous]
        public Boolean ValidateEmail(string email)
        {
            bool validateEmai = false;
            try
            {
                var account = _context.Accounts.AsNoTracking()
                    .SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
                if (account != null)
                {
                    validateEmai = true;
                    return validateEmai;
                }
                return validateEmai;
            }
            catch
            {
                return validateEmai;
            }
        }
        public IActionResult ValidatePhone(string phone)
        {
            try
            {
                var account = _context.Accounts.AsNoTracking()
                    .SingleOrDefault(x => x.Phone.ToLower() == phone.ToLower());
                if (account != null)
                {
                    return Json(data: "Phone Number " + phone + " has been used");
                }
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("register.html")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("register.html")]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            try
            {

                string salt = Extension.GetRandomKey();
                if (ValidateEmail(viewModel.Email) == false)
                {
                    AccountModel account = new AccountModel
                    {
                        AccountId = Guid.NewGuid(),
                        FullName = viewModel.FullName,
                        Phone = viewModel.Phone,
                        Email = viewModel.Email,
                        Password = (viewModel.Password + salt.Trim()).HashMD5(),
                        Active = true,
                        Salt = salt,
                        CreateDate = DateTime.Now,
                    };
                    if (account != null)
                    {
                        _context.Add(account);
                        await _context.SaveChangesAsync();
                        _notyfService.Success("Sign Up Success");
                        return RedirectToAction("Login", "Account");
                    }

                    else return RedirectToAction("Register", "Account");
                }
                else
                {
                    _notyfService.Error("Email has been used!");
                    return RedirectToAction("Register", "Account");

                }
            }
            catch
            {
                return View(viewModel);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("login.html")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("login.html")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
        {
            if (loginViewModel != null)
            {
                bool isEmail = Extension.CheckEmail(loginViewModel.UserName);
                if (!isEmail) { return View(); }
                var account = _context.Accounts.AsNoTracking()
                    .SingleOrDefault(x => x.Email.Trim() == loginViewModel.UserName.Trim());
                if (account == null) { return RedirectToAction("Register"); }
                string pass = (loginViewModel.Password + account.Salt.Trim()).HashMD5();
                if (account.Password != pass || account.Email != loginViewModel.UserName)
                {
                    _notyfService.Error("Login information is not correct");
                    return View(loginViewModel);
                }
                if (account.Active == false)
                {
                    _notyfService.Error("Your account has been locked");
                    return View(loginViewModel);
                }

                // save cookie

                CookieOptions option = new CookieOptions
                {
                    Expires = DateTime.Now.AddMonths(3),
                    Secure = true,
                    HttpOnly = true
                };


                Response.Cookies.Append("User", account.AccountId.ToString(), option);

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, account.FullName),
                    };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddMonths(3)

                }); ;
                _notyfService.Success("Login Success");
                return RedirectToAction("Index", "Home");
            }

            return View(loginViewModel);
        }


        [HttpGet]
        [Route("logout.html")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("User");
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
