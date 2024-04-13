namespace MechanicService.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetByIdReservationQueryHandler : IRequestHandler<GetByIdReservationQuery, GetByIdReservationQueryResult>
    {
        private readonly IRepository<Reservation> _repository;

        public GetByIdReservationQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdReservationQueryResult> Handle(GetByIdReservationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdReservationQueryResult
            {
                Id = values.Id,
                RezCarID = values.RezCarID,
                RezPersonID = values.RezPersonID,
                RezServiceID = values.RezServiceID,
                CreateDate = values.CreateDate,
                IsApproved = values.IsApproved,
                IsCanceled = values.IsCanceled
            };
        }
    }
}
