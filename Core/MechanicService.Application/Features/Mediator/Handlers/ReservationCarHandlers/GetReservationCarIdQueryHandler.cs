namespace MechanicService.Application.Features.Mediator.Handlers.ReservationCarHandlers
{
    public class GetReservationCarIdQueryHandler : IRequestHandler<GetReservationCarIdQuery, GetReservationCarIdQueryResult>
    {
        private readonly IReservationRepository _repository;

        public GetReservationCarIdQueryHandler(IReservationRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetReservationCarIdQueryResult> Handle(GetReservationCarIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetRepositoryCarId();
            return new GetReservationCarIdQueryResult
            {
                ReservationCarId = value,
            };
        }
    }
}
