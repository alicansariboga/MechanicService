using MechanicService.Dto.AppUserDtos;

namespace MechanicService.WebUI.Models
{
    public class ResetPasswordViewModel
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public UpdateAppUserDto UpdateAppUserDto { get; set; }
    }
}
