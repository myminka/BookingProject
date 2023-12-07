namespace Booking.DataAccess.Entities
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string? Name { get; set; }
        public string? Blurb { get; set; }
        public string? Location { get; set; }
        public int NumberOfBedrooms { get; set; }
        public decimal CostPerNight { get; set; }
        public string Description { get; set; }
        public List<Amenity> Amenities { get; set; }
        public List<BookedNight> BookedNights { get; set; }
    }
}
