namespace MechanicService.WebUI.ViewComponents.LocationViewComponents
{
    public class _LocationChoiceComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _LocationChoiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var locationViewModel = new LocationsViewModel();

            var responseMessage = await client.GetAsync("https://localhost:7215/api/LocationCities");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                locationViewModel.CityDatas = JsonConvert.DeserializeObject<List<ResultLocationCityDto>>(jsonData);
            }

            var responseMessage2 = await client.GetAsync($"https://localhost:7215/api/LocationDistricts/GetLocationDistrictsByCityId?id=");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                locationViewModel.DistrictDatas = JsonConvert.DeserializeObject<List<ResultLocationDistrictDto>>(jsonData2);
            }

            return View(locationViewModel);
        }

        [HttpGet]
        public async Task<IViewComponentResult> GetDistrictsByCityId(int cityId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7215/api/LocationDistricts/GetLocationDistrictsByCityId?id={cityId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDistrictDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
