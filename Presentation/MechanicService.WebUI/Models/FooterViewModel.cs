using MechanicService.Dto.AddressDtos;
using MechanicService.Dto.ServiceDtos;
using MechanicService.Dto.SocialMediaDtos;

namespace MechanicService.WebUI.Models
{
    public class FooterViewModel
    {
        public List<ResultServiceDto> ServiceDatas { get; set; }
        public List<ResultAddressDto> AddressDatas { get; set; }
        public List<ResultSocialMediaDto> SocialMediaDatas { get; set; }
    }
}
