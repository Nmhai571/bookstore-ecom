using AspNetCoreHero.ToastNotification.Abstractions;
using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.Models;
using ecom.minhhai.bookstore.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ecom.minhhai.bookstore.Controllers
{
    public class AccountController : Controller
    {
        private readonly BookStoreDbContext _context;
        private readonly UserManager<AccountModel> _userManager;
        private readonly SignInManager<AccountModel> _signInManager;
        private readonly IConfiguration _config;
        public INotyfService _notyfService { get; }

        public AccountController(BookStoreDbContext context, INotyfService notyfService, UserManager<AccountModel> userManager,
            SignInManager<AccountModel> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = configuration;
            _context = context;
            _notyfService = notyfService;
        }
        [Route("my-account.html")]
        public async Task<IActionResult> Dashboard()
        {
            var accountToken = Request.Cookies["User"];
            var jsonToken = new JwtSecurityTokenHandler().ReadToken(accountToken) as JwtSecurityToken;
            if (jsonToken != null)
            {
                // jsonToken.Claims.First(claim => claim.Type == "sid").Value
                var accountId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;
                var account = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == accountId);
                if (account != null)
                {
                    var lsOrder = _context.Orders.AsNoTracking().Include(x => x.OrderDetailModels)
                        .ThenInclude(x => x.BookModel)
                        .Where(x => x.AccountId == account.Id).OrderByDescending(x => x.OrderDate).ToList();
                    ViewBag.ListOrder = lsOrder;
                }
                return View(account);
            }

            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<bool> ValidateEmail(string email)
        {
            bool validateEmail = false;
            try
            {
                AccountModel account = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == email);
                if (account != null)
                {
                    validateEmail = true;
                    return validateEmail;
                }
                return validateEmail;
            }
            catch
            {
                return validateEmail;
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

                if (await ValidateEmail(viewModel.Email) == false)
                {
                    AccountModel account = new AccountModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        FullName = viewModel.FullName,
                        PhoneNumber = viewModel.Phone,
                        Email = viewModel.Email,
                        Active = true,
                        CreateDate = DateTime.Now,
                        UserName = viewModel.Email,
                    };
                    var result = await _userManager.CreateAsync(account, viewModel.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(account, AppicationRole.Customer);
                        _notyfService.Success("Register Success");
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

                var account = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (account == null) { return RedirectToAction("Register"); }
                if (account.Active == false)
                {
                    _notyfService.Error("Your account has been locked");
                    return View(loginViewModel);
                }

                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, true, false);
                if (!result.Succeeded)
                {
                    _notyfService.Error("Login failed");
                    return View(loginViewModel);
                }
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, loginViewModel.Email),
                    new Claim(ClaimTypes.Sid, account.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var userRole = await _userManager.GetRolesAsync(account);
                foreach (var role in userRole)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));
                var token = new JwtSecurityToken(
                    issuer: _config["JWT:ValidIssuer"],
                    audience: _config["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(90),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                    );
                // save token with cookie

                CookieOptions option = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(90),
                    Secure = true,
                    HttpOnly = true,

                };

                Response.Cookies.Append("User", new JwtSecurityTokenHandler().WriteToken(token), option);

                /*var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, account.FullName),
                    };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddMonths(3)

                }); ;*/
                _notyfService.Success("Login Success");
                return RedirectToAction("Index", "Home");
            }

            return View(loginViewModel);
        }

        [HttpGet]
        public async Task LoginWithGoogle()
        {
            if (!User.Identity.IsAuthenticated)
            {
                await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
                {
                    RedirectUri = Url.Action("GoogleResponse"),
                });
            }
            else
            {
                RedirectToAction("Login");
            }

        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(x => new
            {
                x.Issuer,
                x.OriginalIssuer,
                x.Type,
                x.Value
            });
            return Json(claims);
            /*if (result.Succeeded)
            {
                var email = result.Principal.FindFirstValue(ClaimTypes.Email);
                var name = result.Principal.FindFirstValue(ClaimTypes.Name);
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser == null)
                {
                    AccountModel account = new AccountModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        FullName = name,
                        Email = email,
                        Active = true,
                        CreateDate = DateTime.Now,
                        UserName = email,
                    };
                    var addUser = await _userManager.CreateAsync(account);
                    if (addUser.Succeeded == true)
                    {
                        await _signInManager.SignInAsync(account, isPersistent: true);
                        var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, email),
                            new Claim(ClaimTypes.Sid, account.Id),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };
                        var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));
                        var token = new JwtSecurityToken(
                            issuer: _config["JWT:ValidIssuer"],
                            audience: _config["JWT:ValidAudience"],
                            expires: DateTime.Now.AddDays(90),
                            claims: authClaims,
                            signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                            );
                        CookieOptions option = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(90),
                            Secure = true,
                            HttpOnly = true,

                        };

                        Response.Cookies.Append("User", new JwtSecurityTokenHandler().WriteToken(token), option);

                    }
                }
                else
                {
                    await _signInManager.SignInAsync(existingUser, isPersistent: true);
                    var account = await _userManager.FindByEmailAsync(email);
                    var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, email),
                            new Claim(ClaimTypes.Sid, account.Id),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };
                    var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));
                    var token = new JwtSecurityToken(
                        issuer: _config["JWT:ValidIssuer"],
                        audience: _config["JWT:ValidAudience"],
                        expires: DateTime.Now.AddDays(90),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                        );
                    CookieOptions option = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(90),
                        Secure = true,
                        HttpOnly = true,

                    };

                    Response.Cookies.Append("User", new JwtSecurityTokenHandler().WriteToken(token), option);

                }
            }*/

            /*_notyfService.Success("Login Success");
            return RedirectToAction("Index", "Home");*/
        }

        [HttpGet]
        [Route("logout.html")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("User");
            await _signInManager.SignOutAsync();
            _notyfService.Success("Log Out success");
            return RedirectToAction("Index", "Home");
        }
    }
}
