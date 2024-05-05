using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]

    [Area("Admin")]
    [Route("Admin/Pages")]
    public class PagesController : Controller
    {
        [Route("Error404")]
        public IActionResult Error404() // Page Not Found
        {
            return View();
        }
        [Route("Error403")]
        public IActionResult Error403() // Forbidden
        {
            return View();
        }
        [Route("Error401")]
        public IActionResult Error401() // Unauthorized // Access Denied
        {
            return View();
        }
        [Route("Error500")]
        public IActionResult Error500() // Internal Server Error
        {
            return View();
        }
    }
}
