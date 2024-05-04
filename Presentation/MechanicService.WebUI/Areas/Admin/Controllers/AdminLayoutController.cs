using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminHeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminSidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminFooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminScriptPartial()
        {
            return PartialView();
        }
    }
}
