namespace MechanicService.Application.Features.Mediator.Handlers.CarModelHandlers
{
    public class UpdateCarModelCommandHandler : IRequestHandler<UpdateCarModelCommand>
    {
        private readonly IRepository<CarModel> _repository;

        public UpdateCarModelCommandHandler(IRepository<CarModel> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarModelCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.BrandID = request.BrandID;
            values.Name = request.Name;
            values.CarType = request.CarType;
            await _repository.UpdateAsync(values);
        }
    }
}
