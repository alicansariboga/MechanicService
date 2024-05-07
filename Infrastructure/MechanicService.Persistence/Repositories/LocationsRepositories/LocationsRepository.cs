namespace MechanicService.Persistence.Repositories.LocationsRepositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly MechanicServiceContext _context;

        public LocationsRepository(MechanicServiceContext context)
        {
            _context = context;
        }

        public int GetLocationDistrictsByCityId(int id)
        {
            var value = _context.LocationDistricts.Where(x => x.CityID == id && x.IsActive == true).Count();
            return value;
        }

        public List<LocationDistrict> GetLocationDistrictsByCityIdActive(int id)
        {
            var values = _context.LocationDistricts.Where(x => x.CityID == id && x.IsActive == true).ToList();
            return values;
        }

        public List<LocationDistrict> GetLocationDistrictsByCityIdAll(int id)
        {
            var values = _context.LocationDistricts.Where(x => x.CityID == id).ToList();
            return values;
        }

        int ILocationsRepository.GetLocationDistrictsActive()
        {
            var value = _context.LocationDistricts.Where(x => x.IsActive == true).Count();
            return value;
        }
    }
}
