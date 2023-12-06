using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Controllers
{
    public class PropertyListingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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
