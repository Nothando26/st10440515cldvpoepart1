using EventEaseBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventEaseBooking.Controllers
{
    public class VenueController : Controller
    {
        private readonly Models.ApplicationDbContext _context;

        public VenueController(Models.ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Venues.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var venue= await _context.Bookings.FirstOrDefaultAsync(b => b.VenueID == id);

            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }
        public async Task<IActionResult> Delete(int? id)
        {


            var venue = await _context.Bookings.FirstOrDefaultAsync(m => m.VenueID == id);

            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }


        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenueExists(int id)
        {
            return _context.Venues.Any(b => b.VenueID == id);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var venue = await _context.Venues.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

    }
}



    

