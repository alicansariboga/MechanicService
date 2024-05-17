
namespace MechanicService.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7215/api/Services/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultServiceDto>(jsonData);
                ViewBag.values = values.Id;

                var responseMessage2 = await client.GetAsync($"https://localhost:7215/api/Services/GetServiceDescriptionByServiceId?id=" + id);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var values2 = JsonConvert.DeserializeObject<List<ResultServiceDescriptionDto>>(jsonData2);

                    ServiceViewModel serviceViewModel = new ServiceViewModel
                    {
                        ResultService = values,
                        ResultServiceDescription = values2,
                    };
                    return View(serviceViewModel);
                }
            }
            return View();
        }
    }
}
