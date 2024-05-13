namespace MechanicService.Application.Interfaces.BranchOfficeInterfaces
{
    public interface IBranchOfficeRepository
    {
        List<BranchOffice> GetBranchOfficeByDistrictId(int id);
        List<BranchOffice> GetBranchOfficeByDistrictId(int? id);
    }
}
