namespace MechanicService.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAllReservationsCountQueryHandler : IRequestHandler<GetAllReservationsCountQuery, GetAllReservationsCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAllReservationsCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllReservationsCountQueryResult> Handle(GetAllReservationsCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAllReservationsCount();
            return new GetAllReservationsCountQueryResult
            {
                GetAllReservationsCount = values,
            };
        }
    }
}
