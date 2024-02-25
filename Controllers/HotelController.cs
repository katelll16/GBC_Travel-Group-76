using GBC_Travel_Group_76.Data;
using GBC_Travel_Group_76.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_76.Controllers
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var bookings = _context.Hotel.ToList();
            return View(bookings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hotel booking)
        {
            if (ModelState.IsValid)
            {
                _context.Hotel.Add(booking);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

    }
}
