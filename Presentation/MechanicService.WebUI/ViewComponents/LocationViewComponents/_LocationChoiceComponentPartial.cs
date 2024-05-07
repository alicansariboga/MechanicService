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

            var responseMessage = await client.GetAsync("https://localhost:7215/api/LocationCities");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<List<ResultLocationCityDto>>(jsonData);
                return View(results);
            }
            return View();
        }

        [HttpGet]
        public async Task<IViewComponentResult> GetDistrictsByCityId(int cityId)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7215/api/LocationDistricts/GetLocationDistrictsByCityIdActive?id={cityId}");

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
