using Booking.DataAccess.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Controllers
{
    public class BookingController : Controller
    {
        private readonly IPropertyRepository _repository;

        public BookingController(IPropertyRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddBooking(DateTime start, DateTime end, int propertyId)
        {
            _repository.AddBooking(start, end, propertyId);

            return RedirectToAction("ListProperties", "PropertyListing");
        }
    }
}
