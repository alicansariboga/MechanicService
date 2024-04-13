namespace MechanicService.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                RezCarID = request.RezCarID,
                RezPersonID = request.RezPersonID,
                RezServiceID = request.RezServiceID,
                CreateDate = DateTime.Now,
                IsApproved = false,
                IsCanceled = false
            });
        }
    }
}
