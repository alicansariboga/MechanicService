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

                var customerList = new List<ResultCustomerWithCountDto>();

                foreach (var item in customers)
                {
                    // Customer's reservation count
                    var responseMessage2 = await client.GetAsync("https://localhost:7215/api/Customers/CustomerList");
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var customersAll = JsonConvert.DeserializeObject<List<ResultAllCustomerDto>>(jsonData2);

                    var rezCount = customersAll.Where(x => x.IdentityNumber == item.IdentityNumber).ToList().Count;
                    var lastDate = customersAll.Where(x => x.IdentityNumber == item.IdentityNumber).OrderByDescending(x => x.CreateDate).FirstOrDefault().CreateDate;

                    var customerDistinct = new ResultCustomerWithCountDto
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
                        Email = item.Email,
                        RezCount = rezCount,
                        LastDate = lastDate
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
                customerList = customerList.OrderByDescending(x => x.CreateDate).ToList();
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
                customers = customers.OrderByDescending(x => x.CreateDate).ToList();
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
