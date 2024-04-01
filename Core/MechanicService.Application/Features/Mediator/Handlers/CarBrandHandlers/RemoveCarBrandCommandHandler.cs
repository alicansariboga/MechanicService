namespace MechanicService.Application.Features.Mediator.Handlers.CarBrandHandlers
{
    public class RemoveCarBrandCommandHandler : IRequestHandler<RemoveCarBrandCommand>
    {
        private readonly IRepository<CarBrand> _repository;

        public RemoveCarBrandCommandHandler(IRepository<CarBrand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarBrandCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
