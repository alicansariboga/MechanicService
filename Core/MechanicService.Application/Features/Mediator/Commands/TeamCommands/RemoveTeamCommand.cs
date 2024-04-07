namespace MechanicService.Application.Features.Mediator.Commands.TeamCommands
{
    public class RemoveTeamCommand : IRequest
    {
        public RemoveTeamCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
