namespace MechanicService.Application.Features.Mediator.Commands.FaqCommands
{
    public class RemoveFaqCommand : IRequest
    {
        public RemoveFaqCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
