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
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(reservationModel);
            }

            var client = _httpClientFactory.CreateClient();

            var jsonData1 = JsonConvert.SerializeObject(reservationModel.ReservationPerson);
            StringContent stringContent1 = new StringContent(jsonData1, Encoding.UTF8, "application/json");
            var responseMessage1 = await client.PostAsync("https://localhost:7215/api/ReservationPersons", stringContent1);

            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                var createdPerson = JsonConvert.DeserializeObject<ResultReservationPersonDto>(jsonData);
                TempData["RezPersonId"] = createdPerson.Id;
            }

            var jsonData2 = JsonConvert.SerializeObject(reservationModel.ReservationCar);
            StringContent stringContent2 = new StringContent(jsonData2, Encoding.UTF8, "application/json");
            var responseMessage2 = await client.PostAsync("https://localhost:7215/api/ReservationCars", stringContent2);

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var createdCar = JsonConvert.DeserializeObject<ResultReservationCarDto>(jsonData);
                TempData["RezCarId"] = createdCar.Id;
            }

            var jsonData3 = JsonConvert.SerializeObject(reservationModel.ReservationService);
            StringContent stringContent3 = new StringContent(jsonData3, Encoding.UTF8, "application/json");
            var responseMessage3 = await client.PostAsync("https://localhost:7215/api/ReservationServices", stringContent3);

            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                var createdService = JsonConvert.DeserializeObject<ResultReservationServiceDto>(jsonData);
                TempData["RezServiceId"] = createdService.Id;
            }


            return RedirectToAction("Index", "ReservationComplete");
            //return View();
        }
    }
}
