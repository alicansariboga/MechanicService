namespace MechanicService.Application.Features.Mediator.Results.LocationDistrictResults
{
    public class GetLocationDistrictsByCityIdActiveQueryResult
    {
        public int Id { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
