using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using GBC_Travel_Group_76.Models;
using GBC_Travel_Group_76.Data;
using Microsoft.EntityFrameworkCore;

namespace GBC_Travel_Group_76.Controllers
{
    public class CarRentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarRentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var carrent = _context.CarRent.ToList();
            return View(carrent);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var carrent = _context.CarRent.FirstOrDefault(p => p.Id == id);
            if (carrent == null)
            {
                return NotFound();
            }
            return View(carrent);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarRent carrent)
        {
            if (ModelState.IsValid)
            {
                _context.CarRent.Add(carrent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrent);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var carrent = _context.CarRent.Find(id);
            if (carrent == null)
            {
                return NotFound();
            }
            return View(carrent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CarRent carrent)
        {
            if (id != carrent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.CarRent.Update(carrent);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(carrent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(carrent);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var carrent = _context.CarRent.FirstOrDefault(p => p.Id == id);
            if (carrent == null)
            {
                return NotFound();
            }
            return View(carrent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var carrent = _context.CarRent.Find(id);
            if (carrent != null)
            {
                _context.CarRent.Remove(carrent);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Search(string pickuplocation, string dropofflocationn)
        {
            var carrentQuery = from p in _context.CarRent
                              select p;

            bool searchPerformed = !String.IsNullOrEmpty(pickuplocation)
                                || !String.IsNullOrEmpty(dropofflocationn);
                                

            if (searchPerformed)
            {
                if (!String.IsNullOrEmpty(pickuplocation))
                {
                    carrentQuery = carrentQuery.Where(p => p.PickUpLocation.Contains(pickuplocation));
                }

                if (!String.IsNullOrEmpty(dropofflocationn))
                {
                    carrentQuery = carrentQuery.Where(p => p.DropOffLocation.Contains(dropofflocationn));
                }


            }

            var carrent = await carrentQuery.ToListAsync();
            ViewData["SearchedPerformed"] = searchPerformed;
            return View("Index", carrent);
        }
        public IActionResult Book(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrent = _context.CarRent.FirstOrDefault(m => m.Id == id);
            if (carrent == null)
            {
                return NotFound();
            }

            return View(carrent);
        }


        [HttpPost]
        public IActionResult Book(int id, [Bind("Customer,CustomerName")] Booking booking)
        {
           

            if (ModelState.IsValid)
            {
                // Save booking to the database
                _context.Booking.Add(booking);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(booking);
        }



        private bool CarExists(int id)
        {
            return _context.CarRent.Any(p => p.Id == id);
        }
    }
}


