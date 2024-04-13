using MechanicService.Application.Interfaces.LocationsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicService.Persistence.Repositories.LocationsRepositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly MechanicServiceContext _context;

        public LocationsRepository(MechanicServiceContext context)
        {
            _context = context;
        }

        public List<LocationDistrict> GetLocationDistrictsByCityId(int id)
        {
            var values = _context.LocationDistricts.Where(x => x.CityID == id).ToList();
            return values;
        }
    }
}
