﻿namespace BookingProject.Models
{
    public class PropertyListingViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Blurb { get; set; }
        public string? Location { get; set; }
        public int NumberOfBedrooms { get; set; }
        public decimal CostPerNight { get; set; }
    }
}
