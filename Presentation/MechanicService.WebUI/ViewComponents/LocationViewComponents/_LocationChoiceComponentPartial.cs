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
                var values = JsonConvert.DeserializeObject<List<ResultLocationCityDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var locationsViewModel = new LocationsViewModel();

        //    var responseMessage = await client.GetAsync("https://localhost:7215/api/LocationCities");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        locationsViewModel.LocationCityDatas = JsonConvert.DeserializeObject<List<ResultLocationCityDto>>(jsonData);
        //    }

        //    var responseMessage2 = await client.GetAsync("https://localhost:7215/api/LocationDistricts");
        //    if (responseMessage2.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage2.Content.ReadAsStringAsync();
        //        locationsViewModel.LocationDistrictDatas = JsonConvert.DeserializeObject<List<ResultLocationDistrictDto>>(jsonData);
        //    }

        //    return View(locationsViewModel);
        //}
    }
}
