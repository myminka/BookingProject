using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Components.AvailablePropertiesMenu
{
    public class AvailablePropertiesMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
