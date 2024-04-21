namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Reservation")]
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private int lastPersonId = 0;
        private int lastCarId = 0;
        private int lastServiceId = 0;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("AllReservations")]
        public async Task<IActionResult> AllReservations()
        {
            var client = _httpClientFactory.CreateClient();
            var reservationAllViewModel = new ReservationAllViewModel();

            var responseMessage = await client.GetAsync("https://localhost:7215/api/Reservations/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                reservationAllViewModel.Reservations = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsonData);
                ViewBag.ValueControl = reservationAllViewModel.Reservations.Count;
            }
            return View(reservationAllViewModel);
        }
    }
}

//#region Reservation-getPersonId
//var responseMessage4 = await client.GetAsync("https://localhost:7215/api/Reservations/GetReservationPersonId");
//if (responseMessage4.IsSuccessStatusCode)
//{
//    var jsonData = await responseMessage4.Content.ReadAsStringAsync();
//    var value = JsonConvert.DeserializeObject<ResultReservationsIdDto>(jsonData);
//    lastPersonId = value.ReservationPersonId;
//    TempData["PersonId"] = value.ReservationPersonId;
//}
//#endregion

//#region Reservation-getCarId
//var responseMessage5 = await client.GetAsync("https://localhost:7215/api/Reservations/GetReservationCarId");
//if (responseMessage5.IsSuccessStatusCode)
//{
//    var jsonData = await responseMessage5.Content.ReadAsStringAsync();
//    var value = JsonConvert.DeserializeObject<ResultReservationsIdDto>(jsonData);
//    lastCarId = value.ReservationCarId;
//    TempData["CarId"] = value.ReservationCarId;
//}
//#endregion

//#region Reservation-getServiceId
//var responseMessage6 = await client.GetAsync("https://localhost:7215/api/Reservations/GetReservationServiceId");
//if (responseMessage6.IsSuccessStatusCode)
//{
//    var jsonData = await responseMessage6.Content.ReadAsStringAsync();
//    var value = JsonConvert.DeserializeObject<ResultReservationsIdDto>(jsonData);
//    lastServiceId = value.ReservationServiceId;
//    TempData["ServiceId"] = value.ReservationServiceId;
//}
//#endregion

//var responseMessage1 = await client.GetAsync($"https://localhost:7215/api/ReservationPersons/{lastPersonId}");
//if (responseMessage1.IsSuccessStatusCode)
//{
//    var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
//    reservationViewModel.personData = JsonConvert.DeserializeObject<ResultReservationPersonDto>(jsonData1);
//}


//var responseMessage2 = await client.GetAsync($"https://localhost:7215/api/ReservationCars/{lastCarId}");
//if (responseMessage2.IsSuccessStatusCode)
//{
//    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
//    reservationViewModel.carData = JsonConvert.DeserializeObject<ResultReservationCarDto>(jsonData2);
//}

//var responseMessage3 = await client.GetAsync($"https://localhost:7215/api/ReservationServices/{lastServiceId}");
//if (responseMessage3.IsSuccessStatusCode)
//{
//    var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
//    reservationViewModel.serviceData = JsonConvert.DeserializeObject<ResultReservationServiceDto>(jsonData3);
//

//return View(reservationViewModel);