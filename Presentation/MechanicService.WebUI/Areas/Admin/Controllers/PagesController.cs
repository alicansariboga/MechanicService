using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]

    [Area("Admin")]
    [Route("Admin/Pages")]
    public class PagesController : Controller
    {
        [Route("Page404")]
        public IActionResult Page404() // Page Not Found
        {
            return View();
        }
        [Route("Page403")]
        public IActionResult Page403() // Forbidden
        {
            return View();
        }
        [Route("Page401")]
        public IActionResult Page401() // Unauthorized // Access Denied
        {
            return View();
        }
        [Route("Page500")]
        public IActionResult Page500() // Internal Server Error
        {
            return View();
        }
    }
}
