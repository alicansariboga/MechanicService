using MechanicService.Application.Interfaces.LocationsInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    [Route("Admin/ManageLocation")]
    public class ManageLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocationsRepository _locationsRepository;

        public ManageLocationController(IHttpClientFactory httpClientFactory, ILocationsRepository locationsRepository)
        {
            _httpClientFactory = httpClientFactory;
            _locationsRepository = locationsRepository;
        }

        [HttpGet]
        [Route("SelectCity")]
        public async Task<IActionResult> SelectCity()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7215/api/LocationCities");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationCityDto>>(jsonData);

                foreach (var item in values)
                {
                    int activeDistrictCount = _locationsRepository.GetLocationDistrictsByCityId(item.Id);
                    item.ActiveDistrictCount = activeDistrictCount;
                }

                var viewModel = new LocationsViewModel
                {
                    CityDatas = values,
                };

                var districtCount = _locationsRepository.GetLocationDistrictsActive();
                ViewBag.DistrictCount = districtCount;

                return View(viewModel);
            }
            return View();
        }
        [HttpGet]
        [Route("Branch/{id}")]
        public async Task<IActionResult> Branch(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7215/api/LocationDistricts/GetLocationDistrictsByCityIdAll?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDistrictDto>>(jsonData);

                var viewModel = new LocationsViewModel
                {
                    DistrictDatas = values,
                };

                return View(viewModel);
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateBranch/{id}")]
        public async Task<IActionResult> UpdateBranch(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7215/api/LocationDistricts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateLocationDistrictDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateBranch/{id}")]
        public async Task<IActionResult> UpdateBranch(UpdateLocationDistrictDto updateLocationDistrict)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateLocationDistrict);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7215/api/LocationDistricts/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
    }
}
