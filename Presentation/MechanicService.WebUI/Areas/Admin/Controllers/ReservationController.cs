﻿namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Reservation")]
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("AllReservations")]
        public async Task<IActionResult> AllReservations()
        {
            var client = _httpClientFactory.CreateClient();
            var reservationAllViewModel = new ReservationAllViewModel
            {
                ReservationPerson = new ResultReservationPersonDto(),
                ReservationCar = new ResultReservationCarDto(),
                ReservationService = new ResultReservationServiceDto(),
                Reservations = new List<ResultReservationDto>(),
            };

            var responseMessage = await client.GetAsync("https://localhost:7215/api/Reservations/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var reservations = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsonData);

                foreach (var reservation in reservations)
                {
                    var singleRezPersonId = reservation.RezPersonID;
                    var singleRezCarId = reservation.RezCarID;
                    var singleRezServiceId = reservation.RezServiceID;

                    var responsePerson = await client.GetAsync($"https://localhost:7215/api/ReservationPersons/{singleRezPersonId}");
                    if (responsePerson.IsSuccessStatusCode)
                    {
                        var personData = await responsePerson.Content.ReadAsStringAsync();
                        var person = JsonConvert.DeserializeObject<ResultReservationPersonDto>(personData);
                        reservationAllViewModel.ReservationPerson.Name = person.Name;
                    }

                    var responseCar = await client.GetAsync($"https://localhost:7215/api/ReservationCars/{singleRezCarId}");
                    if (responseCar.IsSuccessStatusCode)
                    {
                        var carData = await responseCar.Content.ReadAsStringAsync();
                        var car = JsonConvert.DeserializeObject<ResultReservationCarDto>(carData);
                        reservationAllViewModel.ReservationCar.ModelID = car.ModelID;
                    }

                    var responseService = await client.GetAsync($"https://localhost:7215/api/ReservationServices/{singleRezServiceId}");
                    if (responseService.IsSuccessStatusCode)
                    {
                        var serviceData = await responseService.Content.ReadAsStringAsync();
                        var service = JsonConvert.DeserializeObject<ResultReservationServiceDto>(serviceData);
                        reservationAllViewModel.ReservationService.Date = service.Date;
                    }

                    reservationAllViewModel.Reservations.Add(reservation);
                }

                ViewBag.ValueControl = reservations.Count;
            }

            return View(reservationAllViewModel);
        }
    }
}