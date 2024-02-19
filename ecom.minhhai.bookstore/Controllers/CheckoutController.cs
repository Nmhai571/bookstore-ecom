using AspNetCoreHero.ToastNotification.Abstractions;
using ecom.minhhai.bookstore.Context;
using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.Models;
using ecom.minhhai.bookstore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ecom.minhhai.bookstore.Controllers
{
    
    public class CheckoutController : Controller
    {
        private readonly PaypalClient _paypalClient;
        private readonly UserManager<AccountModel> _userManager;
        private readonly BookStoreDbContext _context;
        public INotyfService _notyfService { get; }

        public CheckoutController(BookStoreDbContext context, INotyfService notyfService,
            UserManager<AccountModel> userManager, PaypalClient paypalClient)
        {
            _paypalClient = paypalClient;
            _userManager = userManager;
            _context = context;
            _notyfService = notyfService;
        }
        public string GetAccountId()
        {
            var accountToken = Request.Cookies["User"];
            var jsonToken = new JwtSecurityTokenHandler().ReadToken(accountToken) as JwtSecurityToken;
            var accountId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;
            return accountId;
        }
        public float GetTotalPriceInCart()
        {
            var cart = HttpContext.Session.Get<List<CartViewModel>>("Cart");
            var totalPrice = (float)cart.Sum(x => x.TotalPrice);
            return totalPrice;

        }
        [HttpGet]
        [Route("checkout.html")]
        [Authorize]
        public async Task<IActionResult> Index()
        {

            var cart = HttpContext.Session.Get<List<CartViewModel>>("Cart");

            var accountId = GetAccountId();
            OrderViewModel order = new OrderViewModel();
            if (accountId != null)
            {
                var account = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == accountId);
                if (account != null)
                {
                    order.CustomerId = Guid.Parse(account.Id);
                    order.FullName = account.FullName;
                    order.Email = account.Email;
                    order.PhoneNumber = account.PhoneNumber;
                    order.Address = account.Address;
                }
                ViewBag.totalPrice = GetTotalPriceInCart();
                ViewData["lsProvince"] = new SelectList(_context.Locations.AsNoTracking().Where(x => x.Levels == 1)
                    .OrderByDescending(x => x.Name).ToList(), "LocationId", "Name");
                ViewBag.Cart = cart;
            }
            ViewBag.PayPalClientId = _paypalClient.ClientId;
            return View(order);
        }

        [HttpPost]
        [Route("checkout.html")]
        [Authorize]
        public async Task<IActionResult> Index(OrderViewModel orderViewModel)
        {
            var cart = HttpContext.Session.Get<List<CartViewModel>>("Cart");
            var accountId = GetAccountId();
            OrderViewModel order = new OrderViewModel();
            if (accountId != null)
            {
                var account = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == accountId); ;
                if (account != null)
                {
                    order.CustomerId = Guid.Parse(account.Id);
                    order.FullName = account.FullName;
                    order.Email = account.Email;
                    order.PhoneNumber = account.PhoneNumber;
                    order.Address = account.Address;

                    account.LocationId = orderViewModel.Province;
                    account.District = orderViewModel.District;
                    account.Ward = orderViewModel.Ward;
                    account.Address = orderViewModel.Address;
                    try
                    {
                        var result = await _userManager.UpdateAsync(account);
                    }
                    catch
                    {
                        _notyfService.Error("Please enter full information");
                        ViewBag.totalPrice = GetTotalPriceInCart();
                        ViewData["lsProvince"] = new SelectList(_context.Locations.AsNoTracking().Where(x => x.Levels == 1)
                            .OrderByDescending(x => x.Name).ToList(), "LocationId", "Name");
                        ViewBag.Cart = cart;
                        return View(order);
                    }

                    
                   /* _context.Update(account);
                    _context.SaveChanges();*/
                }
            }
            try
            {
                OrderModel orderModel = new OrderModel();
                orderModel.OrderId = Guid.NewGuid();
                orderModel.AccountId = accountId;
                orderModel.Address = orderViewModel.Address;
                orderModel.Province = orderViewModel.Province;
                orderModel.District = orderViewModel.District;
                orderModel.Ward = orderViewModel.Ward;
                orderModel.OrderDate = DateTime.Now;
                orderModel.TransactStatusId = 1;
                orderModel.Deleted = false;
                orderModel.Paid = false;
                orderModel.Note = orderViewModel.Note;
                orderModel.TotalPrice = cart.Sum(x => x.TotalPrice);
                _context.Add(orderModel);
                _context.SaveChanges();

                //save order detail
                foreach (var item in cart)
                {
                    OrderDetailModel orderDetail = new OrderDetailModel();
                    orderDetail.OrderDetailModelId = Guid.NewGuid();
                    orderDetail.OrderId = orderModel.OrderId;
                    orderDetail.BookId = item.Book.BookId;
                    orderDetail.Quanlity = item.Quantity;
                    orderDetail.Total = item.TotalPrice;
                    orderDetail.ShipDate = DateTime.Now;
                    _context.Add(orderDetail);
                }

                _context.SaveChanges();
                HttpContext.Session.Remove("Cart");
                _notyfService.Success("Order Success");
                return RedirectToAction("Dashboard", "Account");
            }
            catch (Exception ex)
            {
                
                ViewBag.totalPrice = GetTotalPriceInCart();
                ViewData["lsProvince"] = new SelectList(_context.Locations.AsNoTracking().Where(x => x.Levels == 1)
                    .OrderByDescending(x => x.Name).ToList(), "LocationId", "Name");
                ViewBag.Cart = cart;
                return View(order);
            }
            return View(order);
        }
        [Authorize]
        [HttpPost("/Checkout/create-paypal-order")]
        public async Task<IActionResult> CreatePayPalOrder(CancellationToken cancellationToken)
        {
            var totalPrice = GetTotalPriceInCart().ToString();
            var currencyUnit = "USD";
            var orderID = "DH" + DateTime.Now.Ticks.ToString();
            try
            {
                var response = await _paypalClient.CreateOrder(totalPrice, currencyUnit, orderID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new {ex.GetBaseException().Message};
                return BadRequest(error);
            }
        }

        [Authorize]
        [HttpPost("/Checkout/capture-paypal-order")]
        public async Task<IActionResult> CapturePaypalOrder(string orderID, CancellationToken cancellationToken, [FromBody]OrderViewModel orderViewModel)
        {
            try
            {
                var response = await _paypalClient.CaptureOrder(orderID);
                await Index(orderViewModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new { ex.GetBaseException().Message };
                return BadRequest(error);
            }
        }
    }
}
