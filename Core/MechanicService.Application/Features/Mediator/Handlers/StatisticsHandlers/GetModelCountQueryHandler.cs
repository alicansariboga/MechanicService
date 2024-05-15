namespace MechanicService.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetModelCountQueryHandler : IRequestHandler<GetModelCountQuery, GetModelCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetModelCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetModelCountQueryResult> Handle(GetModelCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetModelCount();
            return new GetModelCountQueryResult
            {
                GetModelCount = values,
            };
        }
    }
}
