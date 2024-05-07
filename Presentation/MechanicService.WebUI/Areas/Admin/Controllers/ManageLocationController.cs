using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/ManageLocation")]
    public class ManageLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ManageLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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

                var viewModel = new LocationsViewModel
                {
                    CityDatas = values,
                };

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
    }
}
