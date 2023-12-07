namespace Booking.DataAccess.Entities
{
    public class BookedNight
    {
        public int BookedNightId { get; set; }
        public DateTime Night { get; set; }

        public Property Property { get; set; }
        public int PropertyId { get; set; }
    }
}
