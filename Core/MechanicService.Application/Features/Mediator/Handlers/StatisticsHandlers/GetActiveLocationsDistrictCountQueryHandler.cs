namespace MechanicService.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetActiveLocationsDistrictCountQueryHandler : IRequestHandler<GetActiveLocationsDistrictCountQuery, GetActiveLocationsDistrictCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetActiveLocationsDistrictCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetActiveLocationsDistrictCountQueryResult> Handle(GetActiveLocationsDistrictCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetActiveLocationsDistrictCount();
            return new GetActiveLocationsDistrictCountQueryResult
            {
                GetActiveLocationsDistrictCount = values,
            };
        }
    }
}
