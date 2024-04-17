using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Runtime.Intrinsics.Arm;
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
            var client = _httpClientFactory.CreateClient();
            var reservationViewModel = new ReservationViewModel();

            #region Reservation-getPersonId
            var responseMessage4 = await client.GetAsync("https://localhost:7215/api/Reservations/GetReservationPerson");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultReservationsIdDto>(jsonData);
                ViewBag.lastPersonId = values.ReservationPersonId;
            }
            #endregion

            #region Reservation-getCarId
            var responseMessage5 = await client.GetAsync("https://localhost:7215/api/Reservations/GetReservationCar");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage5.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultReservationsIdDto>(jsonData);
                ViewBag.lastCarId = values.ReservationCarId;
            }
            #endregion

            #region Reservation-getServiceId
            var responseMessage6 = await client.GetAsync("https://localhost:7215/api/Reservations/GetReservationService");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage6.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultReservationsIdDto>(jsonData);
                ViewBag.lastServiceId = values.ReservationServiceId;
            }
            #endregion

            var responseMessage1 = await client.GetAsync($"https://localhost:7215/api/ReservationPersons/{ViewBag.lastPersonId}");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                reservationViewModel.personData = JsonConvert.DeserializeObject<ResultReservationPersonDto>(jsonData1);
            }


            var responseMessage2 = await client.GetAsync("https://localhost:7215/api/ReservationCar/{ViewBag.lastCarId}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage1.Content.ReadAsStringAsync();
                reservationViewModel.carData = JsonConvert.DeserializeObject<ResultReservationCarDto>(jsonData2);
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7215/api/ReservationService/{ViewBag.lastServiceId}");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage1.Content.ReadAsStringAsync();
                reservationViewModel.serviceData = JsonConvert.DeserializeObject<ResultReservationServiceDto>(jsonData3);
            }
            else
            {
                return RedirectToAction("Error");
            }

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
