using Microsoft.AspNetCore.Mvc;

namespace MechanicService.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
