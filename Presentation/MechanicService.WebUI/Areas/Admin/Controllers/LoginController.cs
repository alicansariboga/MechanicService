using MechanicService.Dto.UserAuthDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]

    [Area("Admin")]
    [Route("Admin/Login")]
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7215/api/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("mechanicServiceToken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                    }
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return View();
        }
        [HttpGet]
        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(CreateRegisterDto createRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createRegisterDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7215/api/Registers/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
