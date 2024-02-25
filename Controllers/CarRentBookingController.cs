using GBC_Travel_Group_76.Data;
using GBC_Travel_Group_76.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GBC_Travel_Group_76.Controllers
{
    public class CarRentBookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarRentBookingController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var booking = _context.Booking.ToList();
            return View(booking);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = _context.Booking.FirstOrDefault(b => b.PassengerId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,UserName,FlightId,BookingDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = _context.Booking.FirstOrDefault(b => b.PassengerId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Model,PickUpLocation,DropOffLocation,Price")] Booking booking)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.PassengerId))
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
            return View(booking);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = _context.Booking.FirstOrDefault(b => b.PassengerId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var booking = _context.Booking.Find(id);
            _context.Booking.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.PassengerId == id);
        }
    }
}
