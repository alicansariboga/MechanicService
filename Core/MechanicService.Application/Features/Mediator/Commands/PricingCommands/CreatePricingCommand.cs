namespace MechanicService.Application.Features.Mediator.Commands.PricingCommands
{
    public class CreatePricingCommand :IRequest
    {
        public string ProcessName { get; set; }
        public double ProcessCost { get; set; }
        public string ProcessCategory { get; set; }
    }
}
