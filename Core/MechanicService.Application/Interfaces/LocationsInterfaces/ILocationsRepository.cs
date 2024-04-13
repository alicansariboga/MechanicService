namespace MechanicService.Application.Interfaces.LocationsInterfaces
{
    public interface ILocationsRepository
    {
        List<LocationDistrict> GetLocationDistrictsByCityId(int id);
    }
}
