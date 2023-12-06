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
                CostPerNight = 350
            },
            new ()
            {
                Id = 2,
                Name = "Safron House",
                Blurb = "Stately home on the Devon moores",
                Location = "Devon",
                NumberOfBedrooms = 7,
                CostPerNight = 730
            }
        };

        public IActionResult ListAll()
        {
            throw new NotImplementedException();
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
