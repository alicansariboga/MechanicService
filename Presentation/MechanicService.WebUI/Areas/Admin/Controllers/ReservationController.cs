using MechanicService.Dto.AppUserDtos;
using MechanicService.WebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
        [HttpPost]
        [Route("AllReservations")]
        public async Task<IActionResult> AllReservations(int Id, string action)
        {
            var client = _httpClientFactory.CreateClient();

            var results = new ResultReservationDto();
            var responseMessage = await client.GetAsync($"https://localhost:7215/api/Reservations/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<ResultReservationDto>(jsonData2);
            }

            if (action == "approve")
            {
                UpdateReservationDto updateReservationDto = new UpdateReservationDto
                {
                    Id = Id,
                    RezPersonID = results.RezPersonID,
                    RezCarID = results.RezCarID,
                    RezServiceID = results.RezServiceID,
                    CreateDate = results.CreateDate,
                    IsApproved = true,
                    IsCanceled = results.IsCanceled,
                };
                var jsonData = JsonConvert.SerializeObject(updateReservationDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage2 = await client.PutAsync("https://localhost:7215/api/Reservations/", stringContent);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllReservations", "Reservation");
                }
            }
            else if (action == "cancel")
            {
                UpdateReservationDto updateReservationDto = new UpdateReservationDto
                {
                    Id = Id,
                    RezPersonID = results.RezPersonID,
                    RezCarID = results.RezCarID,
                    RezServiceID = results.RezServiceID,
                    CreateDate = results.CreateDate,
                    IsApproved = results.IsApproved,
                    IsCanceled = true,
                };
                var jsonData = JsonConvert.SerializeObject(updateReservationDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage2 = await client.PutAsync("https://localhost:7215/api/Reservations/", stringContent);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllReservations", "Reservation");
                }
            }
            return View();
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

        [HttpGet]
        [Route("ReservationInformation/{id}")]
        public async Task<IActionResult> ReservationInformation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reservationAllViewModel = new ReservationDetailViewModel
            {
                ReservationPerson = new ResultReservationPersonDto(),
                ReservationCar = new ResultReservationCarDto(),
                ReservationService = new ResultReservationServiceDto(),
                ReservationCombined = new ResultReservationDetailDto(),

            };

            var responseMessage = await client.GetAsync($"https://localhost:7215/api/Reservations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var reservation = JsonConvert.DeserializeObject<ResultReservationDto>(jsonData);

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
                        reservationAllViewModel.ReservationPerson.IdentityNumber = person.IdentityNumber;
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

                    var combinedReservation = new ResultReservationDetailDto
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
                        IdentityNumber = reservationAllViewModel.ReservationPerson.IdentityNumber,
                        LicensePlate = reservationAllViewModel.ReservationCar.LicensePlate,
                        ReservationDate = reservationAllViewModel.ReservationService.Date,
                        ReservationHour = reservationAllViewModel.ReservationService.Hour,
                    };
                    reservationAllViewModel.ReservationCombined = combinedReservation;
                }
            }
            return View(reservationAllViewModel);
        }
    }
}