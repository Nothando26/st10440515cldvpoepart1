using EventEaseBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EventEaseBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly Models.ApplicationDbContext _context;

        public BookingController(Models.ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return View(bookings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

           
            return View(booking);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingID == id);

            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }
    public async Task<IActionResult> Delete(int? id)
        {
          

            var booking = await _context.Bookings.FirstOrDefaultAsync(m => m.BookingID == id);

            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }


        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(b => b.BookingID == id);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {  
                return NotFound();
            }
               

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

             return View(booking);
        }

    }
}
