using AutoMapper;
using Booking.DataAccess.Abstractions;
using Booking.DataAccess.Entities;
using BookingProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Controllers
{
    public class PropertyManagementController : Controller
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;

        public PropertyManagementController(IPropertyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

            var entity = _mapper.Map<Property>(model);

            _repository.AddProperty(entity);

            return View("ApplyAdding");
        }
    }
}
