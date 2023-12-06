using BookingProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Controllers
{
    public class PropertyManagementController : Controller
    {
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

            return View("ApplyAdding");
        }
    }
}
