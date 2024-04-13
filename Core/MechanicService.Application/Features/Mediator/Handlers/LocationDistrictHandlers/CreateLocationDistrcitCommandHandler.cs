namespace MechanicService.Application.Features.Mediator.Handlers.LocationDistrictHandlers
{
    public class CreateLocationDistrictCommandHandler : IRequestHandler<CreateLocationDistrictCommand>
    {
        private readonly IRepository<LocationDistrict> _repository;

        public CreateLocationDistrictCommandHandler(IRepository<LocationDistrict> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateLocationDistrictCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new LocationDistrict
            {
                CityID = request.CityID,
                Name = request.Name,
                IsActive = request.IsActive
            });
        }
    }
}
