namespace MechanicService.Application.Features.Mediator.Commands.LocationDistrictCommands
{
    public class RemoveLocationDistrictCommand : IRequest
    {
        public RemoveLocationDistrictCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
