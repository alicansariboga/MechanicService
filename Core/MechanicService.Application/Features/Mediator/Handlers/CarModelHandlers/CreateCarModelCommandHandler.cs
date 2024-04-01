namespace MechanicService.Application.Features.Mediator.Handlers.CarModelHandlers
{
    public class CreateCarModelCommandHandler : IRequestHandler<CreateCarModelCommand>
    {
        private readonly IRepository<CarModel> _repository;

        public CreateCarModelCommandHandler(IRepository<CarModel> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarModelCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarModel
            {
                BrandID = request.BrandID,
                Name = request.Name,
                CarType = request.CarType,
            });
        }
    }
}
