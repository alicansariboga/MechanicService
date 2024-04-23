namespace MechanicService.WebUI.Areas.Admin.Controllers
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
                ReservationCombined = new List<ResultReservationAllDto>(),

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
                        reservationAllViewModel.ReservationPerson.Surname = person.Surname;
                    }

                    var responseCar = await client.GetAsync($"https://localhost:7215/api/ReservationCars/{singleRezCarId}");
                    if (responseCar.IsSuccessStatusCode)
                    {
                        var carData = await responseCar.Content.ReadAsStringAsync();
                        var car = JsonConvert.DeserializeObject<ResultReservationCarDto>(carData);
                        reservationAllViewModel.ReservationCar.LicensePlate = car.LicensePlate;
                    }

                    var responseService = await client.GetAsync($"https://localhost:7215/api/ReservationServices/{singleRezServiceId}");
                    if (responseService.IsSuccessStatusCode)
                    {
                        var serviceData = await responseService.Content.ReadAsStringAsync();
                        var service = JsonConvert.DeserializeObject<ResultReservationServiceDto>(serviceData);
                        reservationAllViewModel.ReservationService.Date = service.Date;
                        reservationAllViewModel.ReservationService.Hour = service.Hour;
                    }

                    var combinedReservation = new ResultReservationAllDto
                    {
                        RezServiceID = reservation.RezServiceID,
                        RezCarID = reservation.RezCarID,
                        RezPersonID = reservation.RezPersonID,
                        IsApproved = reservation.IsApproved,
                        CreateDate = reservation.CreateDate,
                        Id = reservation.Id,
                        IsCanceled = reservation.IsCanceled,
                        PersonName = reservationAllViewModel.ReservationPerson.Name,
                        PersonSurname = reservationAllViewModel.ReservationPerson.Surname,
                        LicensePlate = reservationAllViewModel.ReservationCar.LicensePlate,
                        ReservationDate = reservationAllViewModel.ReservationService.Date,
                        ReservationHour = reservationAllViewModel.ReservationService.Hour,
                    };
                    reservationAllViewModel.ReservationCombined.Add(combinedReservation);
                }
            }
            return View(reservationAllViewModel);
        }
        [HttpGet]
        [Route("CompletedReservations")]
        public async Task<IActionResult> CompletedReservations()
        {
            var client = _httpClientFactory.CreateClient();
            var reservationAllViewModel = new ReservationAllViewModel
            {
                ReservationPerson = new ResultReservationPersonDto(),
                ReservationCar = new ResultReservationCarDto(),
                ReservationService = new ResultReservationServiceDto(),
                Reservations = new List<ResultReservationDto>(),
                ReservationCombined = new List<ResultReservationAllDto>(),

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

                    if (reservation.IsApproved == true)
                    {
                        var responsePerson = await client.GetAsync($"https://localhost:7215/api/ReservationPersons/{singleRezPersonId}");
                        if (responsePerson.IsSuccessStatusCode)
                        {
                            var personData = await responsePerson.Content.ReadAsStringAsync();
                            var person = JsonConvert.DeserializeObject<ResultReservationPersonDto>(personData);
                            reservationAllViewModel.ReservationPerson.Name = person.Name;
                            reservationAllViewModel.ReservationPerson.Surname = person.Surname;
                        }

                        var responseCar = await client.GetAsync($"https://localhost:7215/api/ReservationCars/{singleRezCarId}");
                        if (responseCar.IsSuccessStatusCode)
                        {
                            var carData = await responseCar.Content.ReadAsStringAsync();
                            var car = JsonConvert.DeserializeObject<ResultReservationCarDto>(carData);
                            reservationAllViewModel.ReservationCar.LicensePlate = car.LicensePlate;
                        }

                        var responseService = await client.GetAsync($"https://localhost:7215/api/ReservationServices/{singleRezServiceId}");
                        if (responseService.IsSuccessStatusCode)
                        {
                            var serviceData = await responseService.Content.ReadAsStringAsync();
                            var service = JsonConvert.DeserializeObject<ResultReservationServiceDto>(serviceData);
                            reservationAllViewModel.ReservationService.Date = service.Date;
                            reservationAllViewModel.ReservationService.Hour = service.Hour;
                        }

                        var combinedReservation = new ResultReservationAllDto
                        {
                            RezServiceID = reservation.RezServiceID,
                            RezCarID = reservation.RezCarID,
                            RezPersonID = reservation.RezPersonID,
                            IsApproved = reservation.IsApproved,
                            CreateDate = reservation.CreateDate,
                            Id = reservation.Id,
                            IsCanceled = reservation.IsCanceled,
                            PersonName = reservationAllViewModel.ReservationPerson.Name,
                            PersonSurname = reservationAllViewModel.ReservationPerson.Surname,
                            LicensePlate = reservationAllViewModel.ReservationCar.LicensePlate,
                            ReservationDate = reservationAllViewModel.ReservationService.Date,
                            ReservationHour = reservationAllViewModel.ReservationService.Hour,
                        };
                        reservationAllViewModel.ReservationCombined.Add(combinedReservation);
                    }
                }
            }
            return View(reservationAllViewModel);
        }
    }
}