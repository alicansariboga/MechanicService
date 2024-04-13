namespace MechanicService.Application.Features.Mediator.Handlers.ReservationServiceServiceHandlers
{
    public class GetByIdReservationServiceQueryHandler : IRequestHandler<GetByIdReservationServiceQuery, GetByIdReservationServiceQueryResult>
    {
        private readonly IRepository<ReservationService> _repository;

        public GetByIdReservationServiceQueryHandler(IRepository<ReservationService> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdReservationServiceQueryResult> Handle(GetByIdReservationServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdReservationServiceQueryResult
            {
                Id = values.Id,
                City = values.City,
                Distinct = values.Distinct,
                Date = values.Date,
                Hour = values.Hour,
                Description = values.Description
            };
        }
    }
}
