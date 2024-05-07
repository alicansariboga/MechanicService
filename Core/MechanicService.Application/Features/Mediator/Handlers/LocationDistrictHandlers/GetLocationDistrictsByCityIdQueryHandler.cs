
using MechanicService.Application.Interfaces.LocationsInterfaces;

namespace MechanicService.Application.Features.Mediator.Handlers.LocationDistrictHandlers
{
    public class GetLocationDistrictsByCityIdQueryHandler : IRequestHandler<GetLocationDistrictsByCityIdActiveQuery, List<GetLocationDistrictsByCityIdActiveQueryResult>>
    {
        private readonly ILocationsRepository _repository;

        public GetLocationDistrictsByCityIdQueryHandler(ILocationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationDistrictsByCityIdActiveQueryResult>> Handle(GetLocationDistrictsByCityIdActiveQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLocationDistrictsByCityIdActive(request.Id);
            return values.Select(x => new GetLocationDistrictsByCityIdActiveQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                CityID = x.CityID,
                IsActive = x.IsActive,
            }).ToList();
        }
    }
}
