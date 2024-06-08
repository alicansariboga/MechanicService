using Microsoft.AspNetCore.Authorization;
using MailKit.Net.Smtp;
using MimeKit;
using MechanicService.Dto.AppUserDtos;
using MechanicService.Application.Services;
using Newtonsoft.Json.Linq;
using NuGet.Common;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]

    [Area("Admin")]
    [Route("Admin/ResetPassword")]
    public class ResetPasswordController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ResetPasswordController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("ForgetPassword")]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        [Route("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ResultAppUserDto resultAppUserDto)
        {
            string[] parts = resultAppUserDto.Result.Email.Split('@');
            string username = parts[0];
            string domain = parts[1];

            var client = _httpClientFactory.CreateClient();
            int userID = 0;

            var responseMessage = await client.GetAsync("https://localhost:7215/api/AppUsers/GetAppUserByEmail?mail=" + username + "%40" + domain); // @ işareti url de = %40
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResultAppUserDto>(jsonData);
                var user = results.Result;
                userID = user.AppUserID;
            }

            var passwordResetService = new PasswordResetService();

            string passwordResetToken = passwordResetService.GeneratePasswordResetToken(resultAppUserDto.Result.Email);
            var passwordResetTokenLink = Url.Action("ResetPassword", "ResetPassword", new
            {
                userId = userID,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Mekanik Servis", "mechanicserviceproject@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", resultAppUserDto.Result.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Şifre Değişiklik Talebi";

            SmtpClient client1 = new SmtpClient();
            client1.Connect("smtp.gmail.com", 587, false);
            client1.Authenticate("mechanicserviceproject@gmail.com", "vqmvxlyifhmvjhas");
            client1.Send(mimeMessage);
            client1.Disconnect(true);

            return RedirectToAction("MailSent", "ResetPassword");
        }

        [HttpGet]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(int userid, string token)
        {
            TempData["userid="] = userid;
            TempData["token="] = token;

            if (userid == null || token == null)
            {
                // error
                return BadRequest("Kullanıcı kimliği veya token bulunamadı.");
            }
            else
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"https://localhost:7215/api/AppUsers/{userid}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var updateAppUserDto = JsonConvert.DeserializeObject<UpdateAppUserDto>(jsonData);

                    var resetPasswordViewModel = new ResetPasswordViewModel
                    {
                        UpdateAppUserDto = updateAppUserDto
                    };

                    return View(resetPasswordViewModel);
                }
                else
                {
                    return BadRequest("Kullanıcı bulunamadı.");
                }
            }
        }
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (resetPasswordViewModel.Password != resetPasswordViewModel.ConfirmPassword)
            {
                return BadRequest("Şifreler uyuşmuyor.");
            }
            else
            {
                UpdateAppUserDto updateAppUserDto = new UpdateAppUserDto
                {
                    AppUserID = resetPasswordViewModel.UpdateAppUserDto.AppUserID,
                    UserName = resetPasswordViewModel.UpdateAppUserDto.UserName,
                    Password = resetPasswordViewModel.Password,
                    Name = resetPasswordViewModel.UpdateAppUserDto.Name,
                    Surname = resetPasswordViewModel.UpdateAppUserDto.Surname,
                    Email = resetPasswordViewModel.UpdateAppUserDto.Email,
                    AppRoleID = resetPasswordViewModel.UpdateAppUserDto.AppRoleID
                };

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateAppUserDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7215/api/AppUsers/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SignIn", "Login");
                    //return View();
                }
                return View();
            }
        }
        [HttpGet]
        [Route("MailSent")]
        public IActionResult MailSent()
        {
            return View();
        }
    }
}
