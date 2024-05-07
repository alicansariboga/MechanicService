namespace MechanicService.Application.Features.Mediator.Results.LocationDistrictResults
{
    public class GetLocationDistrictsByCityIdAllQueryResult
    {
        public int Id { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
