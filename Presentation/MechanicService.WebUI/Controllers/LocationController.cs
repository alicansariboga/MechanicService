using MechanicService.Application.Interfaces.BranchOfficeInterfaces;
using MechanicService.Domain.Entities;
using MechanicService.Dto.BranchOfficeDtos;

namespace MechanicService.WebUI.Controllers
{
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBranchOfficeRepository _branchOfficeRepository;

        public LocationController(IHttpClientFactory httpClientFactory, IBranchOfficeRepository branchOfficeRepository)
        {
            _httpClientFactory = httpClientFactory;
            _branchOfficeRepository = branchOfficeRepository;
        }

        [Route("Location/Index/{id?}/")]
        public IActionResult Index(int? id)
        {

            if (id != null)
            {
                var results = _branchOfficeRepository.GetBranchOfficeByDistrictId(id);
                var list = new List<ResultBranchOfficeDto>();
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
                    list.Add(branch);
                }
                var branchOffice = new BranchOfficeViewModel
                {
                    BranchOffices = list,
                };
                return View(branchOffice);
            }
            else
            {
                var branchOffice = new BranchOfficeViewModel();
                return View(branchOffice.BranchOffices);
            }
        }
    }
}
