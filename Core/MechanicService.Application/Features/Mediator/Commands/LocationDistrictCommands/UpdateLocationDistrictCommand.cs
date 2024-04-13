namespace MechanicService.Application.Features.Mediator.Commands.LocationDistrictCommands
{
    public class UpdateLocationDistrictCommand : IRequest
    {
        public int Id { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
