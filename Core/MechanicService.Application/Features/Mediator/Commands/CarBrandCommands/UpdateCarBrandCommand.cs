namespace MechanicService.Application.Features.Mediator.Commands.CarBrandCommands
{
    public class UpdateCarBrandCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
    }
}
