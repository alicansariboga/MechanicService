namespace MechanicService.Application.Features.Mediator.Commands.CarModelCommands
{
    public class UpdateCarModelCommand : IRequest
    {
        public int Id { get; set; }
        public int BrandID { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
    }
}
