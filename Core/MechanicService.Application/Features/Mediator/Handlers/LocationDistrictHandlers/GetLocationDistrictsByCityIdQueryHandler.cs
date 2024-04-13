
using MechanicService.Application.Interfaces.LocationsInterfaces;

namespace MechanicService.Application.Features.Mediator.Handlers.LocationDistrictHandlers
{
    public class GetLocationDistrictsByCityIdQueryHandler : IRequestHandler<GetLocationDistrictsByCityIdQuery, List<GetLocationDistrictsByCityIdQueryResult>>
    {
        private readonly ILocationsRepository _repository;

        public GetLocationDistrictsByCityIdQueryHandler(ILocationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationDistrictsByCityIdQueryResult>> Handle(GetLocationDistrictsByCityIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLocationDistrictsByCityId(request.Id);
            return values.Select(x => new GetLocationDistrictsByCityIdQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                CityID = x.CityID,
                IsActive = x.IsActive,
            }).ToList();
        }
    }
}
