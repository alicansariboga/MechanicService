namespace MechanicService.Application.Features.Mediator.Commands.LocationDistrictCommands
{
    public class CreateLocationDistrictCommand : IRequest
    {
        public int CityID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
