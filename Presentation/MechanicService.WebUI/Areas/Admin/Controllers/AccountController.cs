using MechanicService.Application.Interfaces.AppUserInterfaces;
using MechanicService.Domain.Entities;
using MechanicService.Dto.AppUserDtos;
using Microsoft.AspNetCore.Authorization;

namespace MechanicService.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    [Route("Admin/Account")]
    public class AccountController : Controller
    {
        private IAppUserRepository _userRepository;

        public AccountController(IAppUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("AccountInfo")]
        public async Task<IActionResult> AccountInfo()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "mechanicServiceToken")?.Value;
            if (token != null)
            {
                var values = _userRepository.GetUserInfoFromToken(token);
                UpdateAppUserConfirmDto updateAppUsersDto = new UpdateAppUserConfirmDto
                {
                    AppRoleID = values.AppRoleID,
                    AppUserID = values.AppUserID,
                    Email = values.Email,
                    Name = values.Name,
                    Surname = values.Surname,
                    UserName = values.UserName,

                };
                UserAccountViewModel userAccountViewModel = new UserAccountViewModel
                {
                    UpdateAppUser = updateAppUsersDto,
                };
                return View(userAccountViewModel);
            }
            return View();
        }

        [HttpPost]
        [Route("AccountInfo")]
        public async Task<IActionResult> AccountInfo(UserAccountViewModel userAccountViewModel)
        {
            //UpdateAppUserDto updateAppUserConfirmDto = new UpdateAppUserDto
            //{
            //    AppRoleID = userAccountViewModel.UpdateAppUser.AppRoleID,
            //    AppUserID = userAccountViewModel.UpdateAppUser.AppUserID,
            //    Email = userAccountViewModel.UpdateAppUser.Email,
            //    Name = userAccountViewModel.UpdateAppUser.Name,
            //    Surname = userAccountViewModel.UpdateAppUser.Surname,
            //    UserName = userAccountViewModel.UpdateAppUser.UserName,
            //    Password = userAccountViewModel.UpdateAppUser.Password,
            //};
            if(userAccountViewModel.UpdateAppUser.Password == userAccountViewModel.UpdateAppUser.PasswordConfirm)
            {
                AppUser updateAppUser = new AppUser
                {
                    AppRoleID = userAccountViewModel.UpdateAppUser.AppRoleID,
                    AppUserID = userAccountViewModel.UpdateAppUser.AppUserID,
                    Email = userAccountViewModel.UpdateAppUser.Email,
                    Name = userAccountViewModel.UpdateAppUser.Name,
                    Surname = userAccountViewModel.UpdateAppUser.Surname,
                    UserName = userAccountViewModel.UpdateAppUser.UserName,
                    Password = userAccountViewModel.UpdateAppUser.Password,
                };
                _userRepository.UpdateAsync(updateAppUser);
                return RedirectToAction("AccountInfo", "Account");
            }
            else
            {
                return null;
            }
        }
    }
}
