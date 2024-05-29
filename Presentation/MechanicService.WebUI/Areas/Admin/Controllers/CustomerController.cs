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

            var responseMessage = await client.GetAsync("https://localhost:7215/api/Customers/CustomerList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<ResultAllCustomerDto>>(jsonData);
                return View(customers);
            }
            return View();
        }

        [HttpGet]
        [Route("CustomerInformation/{id}")]
        public async Task<IActionResult> CustomerInformation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reservationInformationViewModel = new ReservationInformationViewModel
            {
                ReservationPerson = new ResultReservationPersonDto(),
            };

            var responseMessage = await client.GetAsync($"https://localhost:7215/api/Reservations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var reservation = JsonConvert.DeserializeObject<ResultReservationDto>(jsonData);

                var singleRezPersonId = reservation.RezPersonID;

                var responsePerson = await client.GetAsync($"https://localhost:7215/api/ReservationPersons/{singleRezPersonId}");
                if (responsePerson.IsSuccessStatusCode)
                {
                    var personData = await responsePerson.Content.ReadAsStringAsync();
                    var person = JsonConvert.DeserializeObject<ResultReservationPersonDto>(personData);

                    reservationInformationViewModel.ReservationPerson = person;
                }
            }
            return View(reservationInformationViewModel);
        }
    }
}
