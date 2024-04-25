using System.Globalization;
namespace MechanicService.WebUI.Areas.Admin.Controllers
{
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

                //// Date Ago
                //DateTime sendDate;
                //if (DateTime.TryParseExact(values.SendDate.ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.None, out sendDate))
                //{
                //    var now = DateTime.Now;

                //    var timeDifference = now - sendDate;
                //    string timeAgo;

                //    if (timeDifference.TotalDays < 1)
                //    {
                //        if (timeDifference.TotalHours < 1)
                //        {
                //            timeAgo = $"{(int)timeDifference.TotalMinutes} dakika önce";
                //        }
                //        else
                //        {
                //            timeAgo = $"{(int)timeDifference.TotalHours} saat önce";
                //        }
                //    }
                //    else if (timeDifference.TotalDays < 7)
                //    {
                //        timeAgo = $"{(int)timeDifference.TotalDays} gün önce";
                //    }
                //    else
                //    {
                //        timeAgo = sendDate.ToString("dd.MM.yyyy");
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("Tarih/saat biçimi geçersiz!");
                //}

                return View(values);
            }
            return View();
        }
        [Route("MailDetail")]
        public IActionResult MailDetail()
        {
            return View();
        }
    }
}
