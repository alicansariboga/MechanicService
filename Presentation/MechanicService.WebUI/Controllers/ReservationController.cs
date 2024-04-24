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
        public async Task<IActionResult> Index()
        {
            var viewRezervationModel = new ReservationCreateViewModel
            {
                ReservationCar = new CreateReservationCarDto(),
                ReservationPerson = new CreateReservationPersonDto(),
                ReservationService = new CreateReservationServiceDto(),
            };

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7215/api/Banners");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                viewRezervationModel.ResultReservationServiceDtos = JsonConvert.DeserializeObject<List<ResultReservationServiceDto>>(jsonData);
            }

            return View(viewRezervationModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ReservationCreateViewModel reservationCreateViewModel)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData1 = JsonConvert.SerializeObject(reservationCreateViewModel.ReservationPerson);
            StringContent stringContent1 = new StringContent(jsonData1, Encoding.UTF8, "application/json");
            var responseMessage1 =  await client.PostAsync("https://localhost:7215/api/ReservationPersons", stringContent1);

            var jsonData2 = JsonConvert.SerializeObject(reservationCreateViewModel.ReservationCar);
            StringContent stringContent2 = new StringContent(jsonData2, Encoding.UTF8, "application/json");
            var responseMessage2 = await client.PostAsync("https://localhost:7215/api/ReservationCars", stringContent2);

            var jsonData3 = JsonConvert.SerializeObject(reservationCreateViewModel.ReservationService);
            var reservationServiceControl = JsonConvert.DeserializeObject<ResultReservationServiceDto>(jsonData3);

            StringContent stringContent3 = new StringContent(jsonData3, Encoding.UTF8, "application/json");
            var responseMessage3 = await client.PostAsync("https://localhost:7215/api/ReservationServices", stringContent3);

            if (responseMessage1.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode && responseMessage3.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ReservationComplete");
            }

            return View();
        }
    }
}
