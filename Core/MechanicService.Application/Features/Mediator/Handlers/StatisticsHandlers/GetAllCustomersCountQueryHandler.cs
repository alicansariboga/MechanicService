namespace MechanicService.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAllCustomersCountQueryHandler : IRequestHandler<GetAllCustomersCountQuery, GetAllCustomersCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAllCustomersCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllCustomersCountQueryResult> Handle(GetAllCustomersCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAllCustomersCount();
            return new GetAllCustomersCountQueryResult
            {
                GetAllCustomersCount = values,
            };
        }
    }
}
