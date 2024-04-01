namespace MechanicService.Application.Features.Mediator.Commands.CarModelCommands
{
    public class RemoveCarModelCommand : IRequest
    {
        public RemoveCarModelCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
