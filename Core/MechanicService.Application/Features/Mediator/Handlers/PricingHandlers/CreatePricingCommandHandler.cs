namespace MechanicService.Application.Pricings.Mediator.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Pricing
            {
                ProcessName = request.ProcessName,
                ProcessCost = request.ProcessCost,
                ProcessCategory = request.ProcessCategory,
            });
        }
    }
}
