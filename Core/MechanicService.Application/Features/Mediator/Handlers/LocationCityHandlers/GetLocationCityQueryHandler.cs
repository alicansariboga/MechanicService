namespace MechanicService.Application.Features.Mediator.Handlers.LocationCityHandlers
{
    public class GetLocationCityQueryHandler : IRequestHandler<GetLocationCityQuery, List<GetLocationCityQueryResult>>
    {
        private readonly IRepository<LocationCity> _repository;

        public GetLocationCityQueryHandler(IRepository<LocationCity> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationCityQueryResult>> Handle(GetLocationCityQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetLocationCityQueryResult
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
