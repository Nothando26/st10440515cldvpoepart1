namespace EventEaseBooking.Models
{
    public class Event
    {
        public int EventID { get; set; }


        public string EventName { get; set; }


        public DateTime EventDate { get; set; }

        public string Description { get; set; }


        public int? VenueID { get; set; }


        public virtual Venue Venue { get; set; }


        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
