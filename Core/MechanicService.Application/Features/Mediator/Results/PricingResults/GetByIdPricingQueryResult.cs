namespace MechanicService.Application.Features.Mediator.Results.PricingResults
{
    public class GetByIdPricingQueryResult
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public double ProcessCost { get; set; }
        public string ProcessCategory { get; set; }
    }
}
