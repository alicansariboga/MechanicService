namespace MechanicService.Application.Features.Mediator.Handlers.ReservationCarCarHandlers
{
    public class GetByIdReservationCarQueryHandler : IRequestHandler<GetByIdReservationCarQuery, GetByIdReservationCarQueryResult>
    {
        private readonly IRepository<ReservationCar> _repository;

        public GetByIdReservationCarQueryHandler(IRepository<ReservationCar> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdReservationCarQueryResult> Handle(GetByIdReservationCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdReservationCarQueryResult
            {
                Id = values.Id,
                ModelID = values.ModelID,
                Year = values.Year,
                LicensePlate = values.LicensePlate,
                Km = values.Km,
            };
        }
    }
}
