namespace MechanicService.Application.Features.Mediator.Commands.CarBrandCommands
{
    public class RemoveCarBrandCommand : IRequest
    {
        public RemoveCarBrandCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
