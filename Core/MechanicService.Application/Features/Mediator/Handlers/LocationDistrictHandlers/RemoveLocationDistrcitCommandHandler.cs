namespace MechanicService.Application.Features.Mediator.Handlers.LocationDistrictHandlers
{
    public class RemoveLocationDistrictCommandHandler : IRequestHandler<RemoveLocationDistrictCommand>
    {
        private readonly IRepository<LocationDistrict> _repository;

        public RemoveLocationDistrictCommandHandler(IRepository<LocationDistrict> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveLocationDistrictCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
