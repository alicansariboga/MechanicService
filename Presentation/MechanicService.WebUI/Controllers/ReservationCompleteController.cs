using MailKit.Net.Smtp;
using MimeKit;

namespace MechanicService.WebUI.Controllers
{
    public class ReservationCompleteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationCompleteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private int lastPersonId = 0;
        private int lastCarId = 0;
        private int lastServiceId = 0;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var reservationViewModel = new ReservationViewModel();

            #region Reservation-getPersonId
            var responseMessage4 = await client.GetAsync("https://localhost:7215/api/Reservations/GetReservationPersonId");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultReservationsIdDto>(jsonData);
                lastPersonId = value.ReservationPersonId;
                TempData["PersonId"] = value.ReservationPersonId;
            }
            #endregion

            #region Reservation-getCarId
            var responseMessage5 = await client.GetAsync("https://localhost:7215/api/Reservations/GetReservationCarId");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage5.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultReservationsIdDto>(jsonData);
                lastCarId = value.ReservationCarId;
                TempData["CarId"] = value.ReservationCarId;
            }
            #endregion

            #region Reservation-getServiceId
            var responseMessage6 = await client.GetAsync("https://localhost:7215/api/Reservations/GetReservationServiceId");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage6.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultReservationsIdDto>(jsonData);
                lastServiceId = value.ReservationServiceId;
                TempData["ServiceId"] = value.ReservationServiceId;
            }
            #endregion

            var responseMessage1 = await client.GetAsync($"https://localhost:7215/api/ReservationPersons/{lastPersonId}");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                reservationViewModel.personData = JsonConvert.DeserializeObject<ResultReservationPersonDto>(jsonData1);
            }


            var responseMessage2 = await client.GetAsync($"https://localhost:7215/api/ReservationCars/{lastCarId}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                reservationViewModel.carData = JsonConvert.DeserializeObject<ResultReservationCarDto>(jsonData2);
            }

            var responseMessage3 = await client.GetAsync($"https://localhost:7215/api/ReservationServices/{lastServiceId}");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                reservationViewModel.serviceData = JsonConvert.DeserializeObject<ResultReservationServiceDto>(jsonData3);
            }

            return View(reservationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto, ReservationViewModel mailRequest)
        {
            var client = _httpClientFactory.CreateClient();

            createReservationDto.CreateDate = DateTime.Now;
            createReservationDto.RezPersonID = Convert.ToInt32(TempData["PersonId"]);
            createReservationDto.RezCarID = Convert.ToInt32(TempData["CarId"]);
            createReservationDto.RezServiceID = Convert.ToInt32(TempData["ServiceId"]);
            createReservationDto.IsApproved = true;
            createReservationDto.IsCanceled = true;

            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7215/api/Reservations", stringContent);
            

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Mekanik Servisi - Admin", "mechanicserviceproject@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress(mailRequest.personData.Name, mailRequest.personData.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient clientMail = new SmtpClient();
            clientMail.Connect("smtp.gmail.com", 587, false);
            clientMail.Authenticate("mechanicserviceproject@gmail.com", "vqmvxlyifhmvjhas");
            clientMail.Send(mimeMessage);
            clientMail.Disconnect(true);

            return RedirectToAction("Index", "ReservationDone");
        }
    }
}
