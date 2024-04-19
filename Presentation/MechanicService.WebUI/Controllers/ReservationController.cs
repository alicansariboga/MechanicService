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
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var viewRezervationModel = new ReservationCreateViewModel
            {
                ReservationCar = new CreateReservationCarDto(),
                ReservationPerson = new CreateReservationPersonDto(),
                ReservationService = new CreateReservationServiceDto()
            };
            var viewCarBrand = new CarBrandViewModel();
            var viewLocations = new LocationsViewModel();
            var combinedModel = new CombinedCarViewModel
            {
                CarBrandViewModel = viewCarBrand,
                ReservationCreateViewModel = viewRezervationModel,
                LocationsViewModel = viewLocations
            };

            var responseMessage1 = await client.GetAsync("https://localhost:7215/api/CarBrands");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                combinedModel.CarBrandViewModel.BrandDatas = JsonConvert.DeserializeObject<List<ResultCarBrandDto>>(jsonData);
                //return View(combinedModel.CarBrandViewModel.BrandDatas); 
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7215/api/LocationCities");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                combinedModel.LocationsViewModel.CityDatas = JsonConvert.DeserializeObject<List<ResultLocationCityDto>>(jsonData);
                //return View(combinedModel.LocationsViewModel.CityDatas);
            }

            return View(combinedModel);
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
