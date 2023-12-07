using Booking.DataAccess.Entities;

namespace BookingProject.Models
{
    public class ViewPropertyDetails : PropertyListingViewModel
    {
        public string Description { get; set; }
        public List<Amenity> Amenities { get; set; }
        public List<BookedNight> BookedNights { get; set; }
    }
}
