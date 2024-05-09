using MechanicService.Application.Interfaces.BranchOfficeInterfaces;
using MechanicService.Application.Interfaces.LocationsInterfaces;
using MechanicService.Dto.BranchOfficeDtos;
using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    [Route("Admin/ManageLocation")]
    public class ManageLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocationsRepository _locationsRepository;
        private readonly IBranchOfficeRepository _branchOfficeRepository;

        public ManageLocationController(IHttpClientFactory httpClientFactory, ILocationsRepository locationsRepository, IBranchOfficeRepository branchOfficeRepository)
        {
            _httpClientFactory = httpClientFactory;
            _locationsRepository = locationsRepository;
            _branchOfficeRepository = branchOfficeRepository;
        }

        [HttpGet]
        [Route("SelectCity")]
        public async Task<IActionResult> SelectCity()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7215/api/LocationCities");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationCityDto>>(jsonData);

                foreach (var item in values)
                {
                    int activeDistrictCount = _locationsRepository.GetLocationDistrictsByCityId(item.Id);
                    item.ActiveDistrictCount = activeDistrictCount;
                }

                var viewModel = new LocationsViewModel
                {
                    CityDatas = values,
                };

                var districtCount = _locationsRepository.GetLocationDistrictsActive();
                ViewBag.DistrictCount = districtCount;

                return View(viewModel);
            }
            return View();
        }

        [HttpGet]
        [Route("Branch/{id}")]
        public async Task<IActionResult> Branch(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7215/api/LocationDistricts/GetLocationDistrictsByCityIdAll?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDistrictDto>>(jsonData);

                var viewModel = new LocationsViewModel
                {
                    DistrictDatas = values,
                };

                return View(viewModel);
            }
            return View();
        }

        [HttpGet]
        [Route("GetBranchs/{id}")]
        public async Task<IActionResult> GetBranchs(int id)
        {
            var branchOffice = new List<ResultBranchOfficeDto>();
            var results = _branchOfficeRepository.GetBranchOfficeByDistrictId(id);
            foreach (var item in results)
            {
                var branch = new ResultBranchOfficeDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email,
                    DistrictId = item.DistrictId,
                    ImgUrl = item.ImgUrl,
                    LocationUrl = item.LocationUrl,
                };
                branchOffice.Add(branch);
                return View(branchOffice);
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateBranch/{id}")]
        public async Task<IActionResult> UpdateBranch(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7215/api/BranchOffices/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBranchOfficeDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateBranch/{id}")]
        public async Task<IActionResult> UpdateBranch(UpdateBranchOfficeDto updateBranchOfficeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBranchOfficeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7215/api/BranchOffices/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SelectCity", "ManageLocation");
            }
            return View();
        }
    }
}
