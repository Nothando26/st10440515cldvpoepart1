using Microsoft.Extensions.Logging;

namespace EventEaseBooking.Models
{
    public class Venues
    {

        public int VenueID { get; set; }


        public string VenueName { get; set; }


        public string Location { get; set; }


        public int Capacity { get; set; }


        public string ImageURL { get; set; }


        public virtual ICollection<Event> Events { get; set; }
    }
}
