namespace MechanicService.Application.Features.Mediator.Handlers.CarBrandHandlers
{
    public class UpdateCarBrandCommandHandler : IRequestHandler<UpdateCarBrandCommand>
    {
        private readonly IRepository<CarBrand> _repository;

        public UpdateCarBrandCommandHandler(IRepository<CarBrand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarBrandCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Name = request.Name;
            values.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
