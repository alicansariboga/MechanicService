namespace MechanicService.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetReservationQueryResult
            {
                Id = x.Id,
                RezCarID = x.RezCarID,
                RezPersonID = x.RezPersonID,
                RezServiceID = x.RezServiceID,
                CreateDate = x.CreateDate,
                IsApproved = x.IsApproved,
                IsCanceled = x.IsCanceled
            }).ToList();
        }
    }
}
