namespace MechanicService.Application.Features.Mediator.Handlers.ReservationCarCarHandlers
{
    public class GetReservationCarQueryHandler : IRequestHandler<GetReservationCarQuery, List<GetReservationCarQueryResult>>
    {
        private readonly IRepository<ReservationCar> _repository;

        public GetReservationCarQueryHandler(IRepository<ReservationCar> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationCarQueryResult>> Handle(GetReservationCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetReservationCarQueryResult
            {
                Id = x.Id,
                ModelID = x.ModelID,
                Year = x.Year,
                LicensePlate = x.LicensePlate,
                Km = x.Km,
            }).ToList();
        }
    }
}
