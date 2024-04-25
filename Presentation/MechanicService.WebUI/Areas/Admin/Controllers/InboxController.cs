namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Inbox")]
    public class InboxController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("MailDetail")]
        public IActionResult MailDetail()
        {
            return View();
        }
    }
}
