using MechanicService.Dto.TeamDtos;
using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Inbox")]
    public class InboxController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public InboxController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7215/api/Contacts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);

                ContacViewModel contacViewModel = new ContacViewModel
                {
                    ResultContacts = values,
                };

                return View(contacViewModel);
            }
            return View();
        }
        [HttpPost]
        [Route("Index")]
        public async Task<IActionResult> Index(ContacViewModel contacViewModel)
        {
            var client = _httpClientFactory.CreateClient();

            ContacViewModel contacView = new ContacViewModel
            {
                UpdateContact = contacViewModel.UpdateContact,
            };


            var jsonData = JsonConvert.SerializeObject(contacView.UpdateContact);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7215/api/Contacts/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Inbox");
            }
            return View();
        }
        [Route("MailDetail/{id}")]
        public async Task<IActionResult> MailDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7215/api/Contacts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);

                return View(value);
            }
            return View();
        }
    }
}
