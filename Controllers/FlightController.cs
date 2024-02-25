using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using GBC_Travel_Group_76.Models;
using GBC_Travel_Group_76.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightApp.Controllers
{
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var flight = _context.Flight.ToList();
            return View(flight);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var flight = _context.Flight.FirstOrDefault(p => p.Id == id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Flight.Add(flight);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var flight = _context.Flight.Find(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Flight.Update(flight);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(flight);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var flight = _context.Flight.FirstOrDefault(p => p.Id == id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var flight = _context.Flight.Find(id);
            if (flight != null)
            {
                _context.Flight.Remove(flight);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Search(string origin, string destination, DateTime? departureDate, int? passengers)
        {
            var flightQuery = from p in _context.Flight
                              select p;

            bool searchPerformed = !String.IsNullOrEmpty(origin)
                                || !String.IsNullOrEmpty(destination)
                                || departureDate != null
                                || passengers != null;

            if (searchPerformed)
            {
                if (!String.IsNullOrEmpty(origin))
                {
                    flightQuery = flightQuery.Where(p => p.Origin.Contains(origin));
                }

                if (!String.IsNullOrEmpty(destination))
                {
                    flightQuery = flightQuery.Where(p => p.Destination.Contains(destination));
                }

               
            }

            var flights = await flightQuery.ToListAsync();
            ViewData["SearchedPerformed"] = searchPerformed;
            return View("Index", flights);
        }
        public IActionResult Book(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _context.Flight.FirstOrDefault(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        
        [HttpPost]
        public IActionResult Book(int id, [Bind("Id,PassengerName,PassengerEmail")] Booking booking)
        {
            if (id != booking.PassengerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Save booking to the database
                _context.Booking.Add(booking);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(booking);
        }
    


    private bool FlightExists(int id)
        {
            return _context.Flight.Any(p => p.Id == id);
        }
    }
}


