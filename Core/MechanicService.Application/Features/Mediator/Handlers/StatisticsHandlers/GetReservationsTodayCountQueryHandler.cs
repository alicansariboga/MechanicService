namespace MechanicService.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetReservationsTodayCountQueryHandler : IRequestHandler<GetReservationsTodayCountQuery, GetReservationsTodayCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetReservationsTodayCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetReservationsTodayCountQueryResult> Handle(GetReservationsTodayCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetReservationsTodayCount();
            return new GetReservationsTodayCountQueryResult
            {
                GetReservationsTodayCount = values,
            };
        }
    }
}
