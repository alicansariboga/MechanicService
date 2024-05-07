namespace MechanicService.Application.Interfaces.LocationsInterfaces
{
    public interface ILocationsRepository
    {
        List<LocationDistrict> GetLocationDistrictsByCityIdActive(int id);
        List<LocationDistrict> GetLocationDistrictsByCityIdAll(int id);
    }
}
