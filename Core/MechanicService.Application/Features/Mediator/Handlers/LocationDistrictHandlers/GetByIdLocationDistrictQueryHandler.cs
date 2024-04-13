namespace MechanicService.Application.Features.Mediator.Handlers.LocationDistrictHandlers
{
    public class GetByIdLocationDistrictQueryHandler : IRequestHandler<GetByIdLocationDistrictQuery, GetByIdLocationDistrictQueryResult>
    {
        private readonly IRepository<LocationDistrict> _repository;

        public GetByIdLocationDistrictQueryHandler(IRepository<LocationDistrict> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdLocationDistrictQueryResult> Handle(GetByIdLocationDistrictQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdLocationDistrictQueryResult
            {
                Id = values.Id,
                CityID = values.CityID,
                Name = values.Name,
                IsActive = values.IsActive
            };
        }
    }
}
