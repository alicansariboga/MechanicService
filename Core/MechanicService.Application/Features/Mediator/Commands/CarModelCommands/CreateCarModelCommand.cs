namespace MechanicService.Application.Features.Mediator.Commands.CarModelCommands
{
    public class CreateCarModelCommand : IRequest
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
    }
}
