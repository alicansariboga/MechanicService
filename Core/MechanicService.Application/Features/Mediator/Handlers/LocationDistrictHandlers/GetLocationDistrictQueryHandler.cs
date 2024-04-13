namespace MechanicService.Application.Features.Mediator.Handlers.LocationDistrictHandlers
{
    public class GetLocationDistrictQueryHandler : IRequestHandler<GetLocationDistrictQuery, List<GetLocationDistrictQueryResult>>
    {
        private readonly IRepository<LocationDistrict> _repository;

        public GetLocationDistrictQueryHandler(IRepository<LocationDistrict> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationDistrictQueryResult>> Handle(GetLocationDistrictQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetLocationDistrictQueryResult
            {
                Id = x.Id,
                CityID = x.CityID,
                Name = x.Name,
                IsActive = x.IsActive
            }).ToList();
        }
    }
}
