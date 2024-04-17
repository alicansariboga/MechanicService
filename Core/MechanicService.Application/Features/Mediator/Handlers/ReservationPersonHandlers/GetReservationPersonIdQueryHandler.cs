namespace MechanicService.Application.Features.Mediator.Handlers.ReservationPersonHandlers
{
    public class GetReservationPersonIdQueryHandler : IRequestHandler<GetReservationPersonIdQuery, GetReservationPersonIdQueryResult>
    {
        private readonly IReservationRepository _repository;

        public GetReservationPersonIdQueryHandler(IReservationRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetReservationPersonIdQueryResult> Handle(GetReservationPersonIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetRepositoryPersonId();
            return new GetReservationPersonIdQueryResult
            {
                ReservationPersonId = value,
            };
        }
    }
}
