using System.Text;

namespace MechanicService.WebUI.Controllers
{
    public class ReservationCompleteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationCompleteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            createReservationDto.CreateDate = DateTime.Now;

            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7215/api/Reservation", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Reservation");
            }

            return View();
        }
    }
}
