namespace MechanicService.Application.Pricings.Mediator.Handlers.PricingHandlers
{
    public class GetByIdPricingQueryHandler : IRequestHandler<GetByIdPricingQuery, GetByIdPricingQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetByIdPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdPricingQueryResult> Handle(GetByIdPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdPricingQueryResult
            {
                Id = values.Id,
                ProcessName = values.ProcessName,
                ProcessCost = values.ProcessCost,
                ProcessCategory = values.ProcessCategory,
            };
        }
    }
}
