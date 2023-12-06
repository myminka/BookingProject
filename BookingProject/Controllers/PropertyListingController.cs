using BookingProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Controllers
{
    public class PropertyListingController : Controller
    {
        private static List<PropertyListingViewModel> properties = new()
        {
            new ()
            {
                Id = 1,
                Name = "Rose Cottage",
                Blurb = "Beautiful cottage on the Cornwall coast",
                Location = "Cornwall",
                NumberOfBedrooms = 3,
                CostPerNight = 350m
            },
            new ()
            {
                Id = 2,
                Name = "Safron House",
                Blurb = "Stately home on the Devon moores",
                Location = "Devon",
                NumberOfBedrooms = 7,
                CostPerNight = 730m
            },
            new ()
            {
                Id = 3,
                Name = "Cozy Cottage",
                Blurb = "A charming cottage in the countryside.",
                Location = "Rural Area",
                NumberOfBedrooms = 2,
                CostPerNight = 80.00m
            },
            new ()        
            {
                Id = 4,
                Name = "Modern Apartment",
                Blurb = "Sleek and modern apartment in the heart of the city.",
                Location = "City Center",
                NumberOfBedrooms = 1,
                CostPerNight = 120.00m
            },
        };

        public IActionResult ListProperties()
        {
            return View(properties);
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            return ListProperties();
        }
    }
}
