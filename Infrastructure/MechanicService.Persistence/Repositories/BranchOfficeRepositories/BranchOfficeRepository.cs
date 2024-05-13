using MechanicService.Application.Interfaces.BranchOfficeInterfaces;

namespace MechanicService.Persistence.Repositories.BranchOfficeRepositories
{
    public class BranchOfficeRepository : IBranchOfficeRepository
    {
        private readonly MechanicServiceContext _context;

        public BranchOfficeRepository(MechanicServiceContext context)
        {
            _context = context;
        }
        public List<BranchOffice> GetBranchOfficeByDistrictId(int id)
        {
            // SELECT * FROM BranchOffices WHERE BranchOffices.DistrictId = x
            var values = _context.BranchOffices.Where(x => x.DistrictId == id).ToList();
            return values;
        }
        public List<BranchOffice> GetBranchOfficeByDistrictId(int? id)
        {
            var values = _context.BranchOffices.Where(x => x.DistrictId == id).ToList();
            return values;
        }
    }
}
