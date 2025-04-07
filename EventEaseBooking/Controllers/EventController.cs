using EventEaseBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventEaseBooking.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var Events = await _context.Events.FirstOrDefaultAsync(b => b.EventID == id);

            if (Events == null)
            {
                return NotFound();
            }
            return View(Events);
        }
        public async Task<IActionResult> Delete(int? id)
        {


            var Events = await _context.Events.FirstOrDefaultAsync(m => m.EventID == id);

            if (Events == null)
            {
                return NotFound();
            }
            return View(Events);
        }


        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var events = await _context.Events.FindAsync(id);
            _context.Events.Remove(events);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Events.Any(b => b.EventID == id);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var Events = await _context.Events.FindAsync(id);
            if (Events == null)
            {
                return NotFound();
            }

            return View(Events);
        }

    }
}

    
