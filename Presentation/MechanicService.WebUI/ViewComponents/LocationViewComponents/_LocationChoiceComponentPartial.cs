using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;

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
            int id = 0;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7215/api/LocationCities");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationCityDto>>(jsonData);
                List<SelectListItem> values2 = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.Id.ToString()
                                                }).ToList();
                ViewBag.v1 = values2;
                if (values2.Any())
                {
                    id = int.Parse(values2.First().Value);
                }
            }

            ViewBag.cityId = id;

            var responseMessage2 = await client.GetAsync($"https://localhost:7215/api/LocationDistricts/GetLocationDistrictsByCityId?id=" + id);
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<List<ResultLocationDistrictDto>>(jsonData2);
                List<SelectListItem> values4 = (from x in values3
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.Id.ToString()
                                                }).ToList();
                ViewBag.v2 = values4;
            }

            return View();
        }

        [HttpGet]
        public async Task<IViewComponentResult> GetDistrictsByCityId(int cityId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7215/api/LocationDistricts/GetLocationDistrictsByCityId?id=" + cityId);
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
