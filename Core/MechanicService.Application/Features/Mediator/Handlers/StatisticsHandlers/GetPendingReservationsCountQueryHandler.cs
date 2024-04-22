namespace MechanicService.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetPendingReservationsCountQueryHandler : IRequestHandler<GetPendingReservationsCountQuery, GetPendingReservationsCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetPendingReservationsCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPendingReservationsCountQueryResult> Handle(GetPendingReservationsCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetPendingReservationsCount();
            return new GetPendingReservationsCountQueryResult
            {
                GetPendingReservationsCount = values,
            };
        }
    }
}
