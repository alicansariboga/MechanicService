
namespace MechanicService.Persistence.Repositories.CarModelRepositories
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly MechanicServiceContext _context;

        public CarModelRepository(MechanicServiceContext context)
        {
            _context = context;
        }
        public List<CarModel> GetCarModelsByCarBrandId(int id)
        {
            var values = _context.CarModels.Where(x => x.BrandID == id).ToList();
            return values;
        }
    }
}
