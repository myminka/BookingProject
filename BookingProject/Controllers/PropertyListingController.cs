using Bogus;
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

        public PropertyListingController() 
        {
            var faker = new Faker<ViewPropertyDetails>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Blurb, f => f.Lorem.Sentence())
                .RuleFor(p => p.Location, f => f.Address.City())
                .RuleFor(p => p.NumberOfBedrooms, f => f.Random.Int(1, 5))
                .RuleFor(p => p.CostPerNight, f => f.Random.Decimal(50, 300))
                .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
                .RuleFor(p => p.Amenities, f => f.Make(f.Random.Number(1, 5), () => f.Commerce.Product()))
                .RuleFor(p => p.BookedDates, f => f.Make(f.Random.Number(1, 5), () => f.Date.Future()));

            properties.AddRange(faker.Generate(6));

        }

        public IActionResult ListProperties()
        {
            return View(properties);
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            return ListProperties();
        }

        public IActionResult ViewPropertyDetails(int id)
        {
            var selectedProperty = properties.FirstOrDefault(p => p.Id == id);

            if (selectedProperty == null)
            {
                return NotFound();
            }

            return View(selectedProperty);
        }
    }
}
