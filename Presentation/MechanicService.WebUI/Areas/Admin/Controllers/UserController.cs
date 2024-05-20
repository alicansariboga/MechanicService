using MechanicService.Dto.AppUserDtos;
using MechanicService.Dto.TeamDtos;
using MechanicService.Dto.UserAuthDtos;
using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    [Route("Admin/User")]
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("AllUsers")]
        public async Task<IActionResult> AllUsers()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7215/api/AppUsers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUsersDto>>(jsonData);

                var appUserViewModel = new AppUserViewModel
                {
                    ResultAppUsers = values,
                };

                return View(appUserViewModel);
            }
            return View();
        }
        [HttpPost]
        [Route("AllUsers")]
        public async Task<IActionResult> AllUsers(int AppUserID, int AppRoleID)
        {
            var client = _httpClientFactory.CreateClient();

            var results = new UpdateAppUserDto();
            var responseMessage = await client.GetAsync($"https://localhost:7215/api/AppUsers/{AppUserID}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<UpdateAppUserDto>(jsonData2);
            }

            UpdateAppUserDto updateAppUserDto = new UpdateAppUserDto
            {
                AppUserID = results.AppUserID,
                UserName = results.UserName,
                Password = results.Password,
                Name = results.Name,
                Surname = results.Surname,
                Email = results.Email,
                AppRoleID = AppRoleID,
            };

            var jsonData = JsonConvert.SerializeObject(updateAppUserDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage2 = await client.PutAsync("https://localhost:7215/api/AppUsers", stringContent);
            if (responseMessage2.IsSuccessStatusCode)
            {
                return RedirectToAction("AllUsers", "User");
            }
            return View();
        }
        [HttpGet]
        [Route("CreateUser")]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateRegisterDto createRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createRegisterDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7215/api/Registers/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AllUsers", "User");
            }
            return View();
        }
    }
}
