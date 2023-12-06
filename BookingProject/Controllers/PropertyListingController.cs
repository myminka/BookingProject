using Bogus;
using BookingProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Controllers
{
    public class PropertyListingController : Controller
    {
        private static List<ViewPropertyDetails> properties = new();

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

            properties.AddRange(faker.Generate(30));

        }

        public IActionResult ListProperties()
        {
            return View(properties);
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            var availableProperties = properties
                .Where(p => !p.BookedDates.Any(date => date >= start && date <= end))
                .ToList();

            return View("ListProperties", availableProperties);
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
