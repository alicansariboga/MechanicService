namespace MechanicService.Application.Features.Mediator.Handlers.ReservationServiceServiceHandlers
{
    public class GetReservationServiceQueryHandler : IRequestHandler<GetReservationServiceQuery, List<GetReservationServiceQueryResult>>
    {
        private readonly IRepository<ReservationService> _repository;

        public GetReservationServiceQueryHandler(IRepository<ReservationService> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationServiceQueryResult>> Handle(GetReservationServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetReservationServiceQueryResult
            {
                Id = x.Id,
                City = x.City,
                Distinct = x.Distinct,
                Date = x.Date,
                Hour = x.Hour,
                Description = x.Description
            }).ToList();
        }
    }
}
