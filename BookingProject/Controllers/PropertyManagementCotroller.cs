using Booking.DataAccess.Abstractions;
using Booking.DataAccess.Entities;
using BookingProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Controllers
{
    public class PropertyManagementController : Controller
    {
        private readonly IPropertyRepository _repository;

        public PropertyManagementController(IPropertyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult AddProperty()
        {
            var model = new PropertyDetailsModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddProperty(PropertyDetailsModel model)
        {
            // add to repository
            if(model is null)
            {
                NotFound();
            }

            var entity = new Property()
            {
                Description = model.Description,
                Location = model.Location,
                Name = model.Name,
                NumberOfBedrooms = model.NumberOfBedrooms,
                Blurb = model.Blurb,
                CostPerNight = model.CostPerNight,
                BookedNights = new List<BookedNight>(),
                Amenities = new List<Amenity>()
            };

            _repository.AddProperty(entity);

            return View("ApplyAdding");
        }
    }
}
