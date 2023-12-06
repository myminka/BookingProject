namespace BookingProject.Models
{
    public class ViewPropertyDetails : PropertyListingViewModel
    {
        public string Description { get; set; }
        public List<string> Amenities { get; set; }
        public List<DateTime> BookedDates { get; set; }
    }
}
