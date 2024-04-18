using MechanicService.Dto.BannerDtos;
using System.Text;

namespace MechanicService.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new ReservationCreateViewModel
            {
                ReservationCar = new CreateReservationCarDto(),
                ReservationPerson = new CreateReservationPersonDto(),
                ReservationService = new CreateReservationServiceDto()
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ReservationCreateViewModel reservationModel)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData1 = JsonConvert.SerializeObject(reservationModel.ReservationPerson);
            StringContent stringContent1 = new StringContent(jsonData1, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7215/api/ReservationPersons", stringContent1);

            var jsonData2 = JsonConvert.SerializeObject(reservationModel.ReservationCar);
            StringContent stringContent2 = new StringContent(jsonData2, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7215/api/ReservationCars", stringContent2);

            var jsonData3 = JsonConvert.SerializeObject(reservationModel.ReservationService);
            StringContent stringContent3 = new StringContent(jsonData3, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7215/api/ReservationServices", stringContent3);

            return RedirectToAction("Index", "ReservationComplete");
        }
    }
}
