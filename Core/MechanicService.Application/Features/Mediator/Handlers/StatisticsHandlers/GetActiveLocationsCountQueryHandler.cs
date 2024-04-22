namespace MechanicService.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetActiveLocationsCountQueryHandler : IRequestHandler<GetActiveLocationsCountQuery, GetActiveLocationsCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetActiveLocationsCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetActiveLocationsCountQueryResult> Handle(GetActiveLocationsCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetActiveLocationsCount();
            return new GetActiveLocationsCountQueryResult
            {
                GetActiveLocations = values,
            };
        }
    }
}
