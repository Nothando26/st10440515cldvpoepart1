using Microsoft.Extensions.Logging;

namespace EventEaseBooking.Models
{
    public class Booking
    {
        public int BookingID { get; set; }


        public DateTime BookingDate { get; set; }


        public int VenueID { get; set; }


        public virtual Venue Venue { get; set; }
        public int EventID { get; set; }


        public virtual Event Event { get; set; }
    }
}
