using Bogus;
using Booking.DataAccess.Abstractions;
using BookingProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Controllers
{
    public class PropertyListingController : Controller
    {
        private readonly IPropertyRepository _repository;

        public PropertyListingController(IPropertyRepository repository) 
        {
            _repository = repository;
        }

        public IActionResult ListProperties()
        {
            var properties = _repository.GetAllProperties();
            return View(properties);
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            var availableProperties = _repository.GetAvailableProperties(start, end);

            return View("ListProperties", availableProperties);
        }

        public IActionResult ViewPropertyDetails(int id)
        {
            var selectedProperty = _repository.GetPropertyDetails(id);

            if (selectedProperty == null)
            {
                return NotFound();
            }

            return View(selectedProperty);
        }
    }
}
