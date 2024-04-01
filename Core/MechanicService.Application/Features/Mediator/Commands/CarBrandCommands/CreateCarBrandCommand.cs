namespace MechanicService.Application.Features.Mediator.Commands.CarBrandCommands
{
    public class CreateCarBrandCommand : IRequest
    {
        public string Name { get; set; }
        public string IconUrl { get; set; }
    }
}
