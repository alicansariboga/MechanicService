using MechanicService.Application.Interfaces.BranchOfficeInterfaces;
using MechanicService.Application.Interfaces.LocationsInterfaces;
using MechanicService.Dto.BranchOfficeDtos;
using MechanicService.Dto.TeamDtos;
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

				var responseMessage2 = await client.GetAsync("https://localhost:7215/api/Statistics/GetActiveLocationsCityCount");
				if (responseMessage2.IsSuccessStatusCode)
				{
					var jsonData1 = await responseMessage2.Content.ReadAsStringAsync();
					var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
					ViewBag.activeLocationCities = values1.GetActiveLocationsCityCount;
				}

				var responseMessage3 = await client.GetAsync("https://localhost:7215/api/Statistics/GetActiveLocationsCount/");
				if (responseMessage3.IsSuccessStatusCode)
				{
					var jsonData1 = await responseMessage3.Content.ReadAsStringAsync();
					var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
					ViewBag.activeLocations = values1.GetActiveLocationsCount;
				}

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
            ViewBag.DistrictId = id;
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
        [Route("Create/{id}")]
        public IActionResult Create(int id)
        {
            ViewBag.DistrictId = id;
            return View();
        }
        [HttpPost]
        [Route("Create/{id}")]
        public async Task<IActionResult> Create(CreateBranchOfficeDto branchOfficeDto, UpdateBranchOfficeDto updateBranchOfficeDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(branchOfficeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7215/api/BranchOffices/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                int id = branchOfficeDto.DistrictId;

                var responseMessage3 = await client.GetAsync($"https://localhost:7215/api/LocationDistricts/{id}");
                if (responseMessage3.IsSuccessStatusCode)
                {
                    var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<ResultLocationDistrictDto>(jsonData3);


                    UpdateLocationDistrictDto updateLocationDistrictDto = new UpdateLocationDistrictDto
                    {
                        Id = value.Id,
                        CityID = value.CityID,
                        Name = value.Name,
                        IsActive = true,
                    };

                    var jsonData4 = JsonConvert.SerializeObject(updateLocationDistrictDto);
                    StringContent stringContent4 = new StringContent(jsonData4, Encoding.UTF8, "application/json");
                    var responseMessage4 = await client.PutAsync("https://localhost:7215/api/LocationDistricts/", stringContent4);
                    if (responseMessage4.IsSuccessStatusCode)
                    {
                        return RedirectToAction("SelectCity", "ManageLocation");
                    }
                }

                var jsonData2 = JsonConvert.SerializeObject(updateBranchOfficeDto);
                StringContent stringContent2 = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var responseMessage2 = await client.PutAsync("https://localhost:7215/api/BranchOffices/", stringContent2);

                return RedirectToAction("SelectCity", "ManageLocation");
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
