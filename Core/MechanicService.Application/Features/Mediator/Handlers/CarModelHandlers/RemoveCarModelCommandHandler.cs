namespace MechanicService.Application.Features.Mediator.Handlers.CarModelHandlers
{
    namespace MechanicService.Application.Features.Mediator.Handlers.CarModelHandlers
    {
        public class RemoveCarModelCommandHandler : IRequestHandler<RemoveCarModelCommand>
        {
            private readonly IRepository<CarModel> _repository;

            public RemoveCarModelCommandHandler(IRepository<CarModel> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveCarModelCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                await _repository.RemoveAsync(value);
            }
        }
    }
}
