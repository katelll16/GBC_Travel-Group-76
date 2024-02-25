using GBC_Travel_Group_76.Data;
using GBC_Travel_Group_76.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_76.Controllers
{
    public class HotelBookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelBookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var hotelBookings = _context.Hotel.ToList();
            return View(hotelBookings);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelBooking = _context.Hotel.FirstOrDefault(b => b.Id == id);

            if (hotelBooking == null)
            {
                return NotFound();
            }

            return View(hotelBooking);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HotelBooking hotelBooking)
        {
            if (ModelState.IsValid)
            {
                _context.HotelBookings.Add(hotelBooking); // Corrected DbSet
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelBooking);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelBooking = _context.Hotel.FirstOrDefault(b => b.Id == id);

            if (hotelBooking == null)
            {
                return NotFound();
            }

            return View(hotelBooking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, HotelBooking hotelBooking)
        {
            if (id != hotelBooking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(hotelBooking);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelBooking);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelBooking = _context.Hotel.FirstOrDefault(b => b.Id == id);

            if (hotelBooking == null)
            {
                return NotFound();
            }

            return View(hotelBooking);
        }

        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var hotelBooking = _context.Hotel.FirstOrDefault(b => b.Id == id);

            if (hotelBooking != null)
            {
                _context.Hotel.Remove(hotelBooking);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }


}
