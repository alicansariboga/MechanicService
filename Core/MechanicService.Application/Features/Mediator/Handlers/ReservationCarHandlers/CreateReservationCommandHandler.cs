namespace MechanicService.Application.Features.Mediator.Handlers.ReservationCarCarHandlers
{
    public class CreateReservationCarCommandHandler : IRequestHandler<CreateReservationCarCommand>
    {
        private readonly IRepository<ReservationCar> _repository;

        public CreateReservationCarCommandHandler(IRepository<ReservationCar> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCarCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new ReservationCar
            {
                ModelID = request.ModelID,
                Year = request.Year,
                LicensePlate = request.LicensePlate,
                Km = request.Km
            });
        }
    }
}
