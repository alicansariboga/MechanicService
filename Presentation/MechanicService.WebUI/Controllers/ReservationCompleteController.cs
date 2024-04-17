using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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
        public async Task<IActionResult> Index()
        {
            var personId = TempData["PersonId"];
            var carId = TempData["CarId"];
            var serviceId = TempData["ServiceId"];

            if (personId == null || carId == null || serviceId == null)
            {
                return RedirectToAction("Error");
            }

            var client = _httpClientFactory.CreateClient();
            var reservationViewModel = new ReservationViewModel();

            var responseMessage1 = await client.GetAsync($"https://localhost:7215/api/ReservationPerson/{personId}");
            if (responseMessage1.IsSuccessStatusCode)
            {
                return RedirectToAction("Error");
            }

            var responseMessage2 = await client.GetAsync($"https://localhost:7215/api/ReservationCar/{carId}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                return RedirectToAction("Error");
            }

            var responseMessage3 = await client.GetAsync($"https://localhost:7215/api/ReservationService/{serviceId}");
            if (responseMessage3.IsSuccessStatusCode)
            {
                return RedirectToAction("Error");
            }

            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            reservationViewModel.personData = JsonConvert.DeserializeObject<ResultReservationPersonDto>(jsonData1);

            var jsonData2 = await responseMessage1.Content.ReadAsStringAsync();
            reservationViewModel.carData = JsonConvert.DeserializeObject<ResultReservationCarDto>(jsonData2);

            var jsonData3 = await responseMessage1.Content.ReadAsStringAsync();
            reservationViewModel.serviceData = JsonConvert.DeserializeObject<ResultReservationServiceDto>(jsonData3);

            return View(reservationViewModel);
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
