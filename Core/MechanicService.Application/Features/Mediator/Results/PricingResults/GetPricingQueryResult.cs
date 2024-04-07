namespace MechanicService.Application.Features.Mediator.Results.PricingResults
{
    public class GetPricingQueryResult
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public double ProcessCost { get; set; }
        public string ProcessCategory { get; set; }
    }
}
