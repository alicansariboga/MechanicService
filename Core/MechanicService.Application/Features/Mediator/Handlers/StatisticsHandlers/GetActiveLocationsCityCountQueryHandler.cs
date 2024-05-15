namespace MechanicService.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetActiveLocationsCityCountQueryHandler : IRequestHandler<GetActiveLocationsCityCountQuery, GetActiveLocationsCityCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetActiveLocationsCityCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetActiveLocationsCityCountQueryResult> Handle(GetActiveLocationsCityCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetActiveLocationsCityCount();
            return new GetActiveLocationsCityCountQueryResult
            {
                GetActiveLocationsCityCount = values,
            };
        }
    }
}
