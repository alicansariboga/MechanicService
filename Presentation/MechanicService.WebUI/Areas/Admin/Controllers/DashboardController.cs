namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Dashboard")]
    public class DashboardController : Controller
    {
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}