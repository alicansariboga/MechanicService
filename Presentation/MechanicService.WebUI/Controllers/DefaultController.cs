using Microsoft.AspNetCore.Mvc;

namespace MechanicService.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
