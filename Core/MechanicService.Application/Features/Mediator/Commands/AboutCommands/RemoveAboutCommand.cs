namespace MechanicService.Application.Features.Mediator.Commands.AboutCommands
{
    public class RemoveAboutCommand : IRequest
    {
        public RemoveAboutCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
