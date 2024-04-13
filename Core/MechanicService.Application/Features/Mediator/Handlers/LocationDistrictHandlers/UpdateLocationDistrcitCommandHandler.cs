namespace MechanicService.Application.Features.Mediator.Handlers.LocationDistrictHandlers
{
    public class UpdateLocationDistrictCommandHandler : IRequestHandler<UpdateLocationDistrictCommand>
    {
        private readonly IRepository<LocationDistrict> _repository;

        public UpdateLocationDistrictCommandHandler(IRepository<LocationDistrict> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationDistrictCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.CityID = request.CityID;
            values.Name = request.Name;
            values.IsActive = request.IsActive;
            await _repository.UpdateAsync(values);
        }
    }
}
