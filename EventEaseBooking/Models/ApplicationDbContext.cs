using Microsoft.EntityFrameworkCore;

namespace EventEaseBooking.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Venues> Venues { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
