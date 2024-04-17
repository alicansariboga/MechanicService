namespace MechanicService.Application.Features.Mediator.Handlers.ReservationServiceHandlers
{
    public class GetReservationServiceIdQueryHandler : IRequestHandler<GetReservationServiceIdQuery, GetReservationServiceIdQueryResult>
    {
        private readonly IReservationRepository _repository;

        public GetReservationServiceIdQueryHandler(IReservationRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetReservationServiceIdQueryResult> Handle(GetReservationServiceIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetRepositoryServiceId();
            return new GetReservationServiceIdQueryResult
            {
                ReservationServiceId = value,
            };
        }
    }
}
