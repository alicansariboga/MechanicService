namespace MechanicService.Application.Features.Mediator.Commands.PricingCommands
{
    public class UpdatePricingCommand : IRequest
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public double ProcessCost { get; set; }
        public string ProcessCategory { get; set; }
    }
}
