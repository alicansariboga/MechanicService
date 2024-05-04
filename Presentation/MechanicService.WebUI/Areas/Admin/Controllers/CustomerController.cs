using MechanicService.Dto.CustomerDtos;
using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Customer")]
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("AllCustomers")]
        public async Task<IActionResult> AllCustomers()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7215/api/Customers/CustomersReservationsList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<ResultAllCustomerDto>>(jsonData);

                var customerList = new List<ResultCustomersDto>();

                foreach (var item in customers)
                {
                    var customerDistinct = new ResultCustomersDto
                    {
                         Id = item.Id,
                         RezPersonID = item.RezPersonID,
                         CreateDate = item.CreateDate,
                         IsApproved = item.IsApproved,
                         IsCanceled = item.IsCanceled,
                         PersonId = item.PersonId,
                         Name = item.Name,
                         Surname = item.Surname,
                         IdentityNumber = item.IdentityNumber,
                         Phone = item.Phone,
                         PhoneOpt = item.PhoneOpt,
                         Email = item.Email
                    };
                    if (customerList.Count == 0)
                    {
                        customerList.Add(customerDistinct);
                    }
                    else
                    {
                        bool isDuplicate = false;
                        foreach (var customer in customerList)
                        {
                            if (customer.IdentityNumber == customerDistinct.IdentityNumber)
                            {
                                isDuplicate = true;
                                break;
                            }
                        }

                        if (!isDuplicate)
                        {
                            customerList.Add(customerDistinct);
                        }
                    }
                }
                return View(customerList);
            }
            return View();
        }
        
        [HttpGet]
        [Route("CustomersRecords")]
        public async Task<IActionResult> CustomersRecords()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7215/api/Customers/CustomersReservationsList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<ResultAllCustomerDto>>(jsonData);
                return View(customers);
            }
            return View();
        }
        [HttpGet]
        [Route("Detail")]
        public async Task<IActionResult> Detail()
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
