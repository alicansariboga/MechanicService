namespace MechanicService.Application.Pricings.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.ProcessName = request.ProcessName;
            values.ProcessCost = request.ProcessCost;
            values.ProcessCategory = request.ProcessCategory;
            await _repository.UpdateAsync(values);
        }
    }
}
