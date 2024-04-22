namespace MechanicService.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCompletedReservationsCountQueryHandler : IRequestHandler<GetCompletedReservationsCountQuery, GetCompletedReservationsCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCompletedReservationsCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCompletedReservationsCountQueryResult> Handle(GetCompletedReservationsCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCompletedReservationsCount();
            return new GetCompletedReservationsCountQueryResult
            {
                GetCompletedReservationsCount = values,
            };
        }
    }
}
