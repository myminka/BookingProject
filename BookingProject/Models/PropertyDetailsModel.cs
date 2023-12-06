namespace BookingProject.Models
{
    public class PropertyDetailsModel
    {
        public string? Name { get; set; }
        public string? Blurb { get; set; }
        public string? Location { get; set; }
        public int NumberOfBedrooms { get; set; }
        public decimal CostPerNight { get; set; }
        public string Description { get; set; }
        public List<string> Amenities { get; set; }
    }
}
