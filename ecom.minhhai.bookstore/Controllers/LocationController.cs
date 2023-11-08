using AspNetCoreHero.ToastNotification.Abstractions;
using ecom.minhhai.bookstore.Context;
using Microsoft.AspNetCore.Mvc;

namespace ecom.minhhai.bookstore.Controllers
{
    public class LocationController : Controller
    {
        private readonly BookStoreDbContext _context;
        public INotyfService _notyfService { get; }

        public LocationController(BookStoreDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetDistrict(Guid locationId)
        {
            var districts = _context.Locations.OrderBy(x => x.LocationId)
                .Where(x => x.Parent == locationId && x.Levels == 2)
                .OrderBy(x => x.Name).ToList();
            return Json(districts);
        }
        public IActionResult GetWard(Guid locationId)
        {
            var wards = _context.Locations.OrderBy(x => x.LocationId)
                .Where(x => x.Parent == locationId && x.Levels == 3)
                .OrderBy(x => x.Name).ToList();
            return Json(wards);
        }
            

    }
}
