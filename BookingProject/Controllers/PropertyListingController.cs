using AutoMapper;
using Bogus;
using Booking.DataAccess.Abstractions;
using BookingProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Controllers
{
    public class PropertyListingController : Controller
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;

        public PropertyListingController(IPropertyRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult ListProperties()
        {
            var properties = _repository.GetAllProperties().ToList();

            var viewModelsProperties = _mapper.Map<List<ViewPropertyDetails>>(properties);

            return View(viewModelsProperties);
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            var availableProperties = _repository.GetAvailableProperties(start, end).ToList();

            var viewModelProperties = _mapper.Map<List<ViewPropertyDetails>>(availableProperties);

            return View("ListProperties", viewModelProperties);
        }

        public IActionResult ViewPropertyDetails(int id)
        {
            var selectedProperty = _repository.GetPropertyDetails(id);

            if (selectedProperty == null)
            {
                return NotFound();
            }

            var viewModelSelectedProperties = _mapper.Map<ViewPropertyDetails>(selectedProperty);

            return View(viewModelSelectedProperties);
        }
    }
}
