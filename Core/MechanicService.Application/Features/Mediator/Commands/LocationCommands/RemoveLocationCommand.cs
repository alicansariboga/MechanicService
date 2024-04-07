namespace MechanicService.Application.Features.Mediator.Commands.LocationCommands
{
    public class RemoveLocationCommand : IRequest
    {
        public RemoveLocationCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
