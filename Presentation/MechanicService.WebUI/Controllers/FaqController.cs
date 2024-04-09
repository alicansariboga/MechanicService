using MechanicService.Dto.FaqDtos;
using Newtonsoft.Json;

namespace MechanicService.WebUI.Controllers
{
    public class FaqController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FaqController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7215/api/Faqs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFaqDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
