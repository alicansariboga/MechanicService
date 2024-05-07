using MechanicService.Application.Interfaces.LocationsInterfaces;

namespace MechanicService.Application.Features.Mediator.Handlers.LocationDistrictHandlers
{
    public class GetLocationDistrictsByCityIdAllQueryHandler : IRequestHandler<GetLocationDistrictsByCityIdAllQuery, List<GetLocationDistrictsByCityIdAllQueryResult>>
    {
        private readonly ILocationsRepository _repository;

        public GetLocationDistrictsByCityIdAllQueryHandler(ILocationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationDistrictsByCityIdAllQueryResult>> Handle(GetLocationDistrictsByCityIdAllQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLocationDistrictsByCityIdAll(request.Id);
            return values.Select(x => new GetLocationDistrictsByCityIdAllQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                CityID = x.CityID,
                IsActive = x.IsActive,
            }).ToList();
        }
    }
}
