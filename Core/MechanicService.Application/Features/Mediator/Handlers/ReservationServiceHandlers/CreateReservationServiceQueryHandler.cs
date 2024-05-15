namespace MechanicService.Application.Features.Mediator.Handlers.ReservationServiceServiceHandlers
{
    public class CreateReservationServiceCommandHandler : IRequestHandler<CreateReservationServiceCommand>
    {
        private readonly IRepository<ReservationService> _repository;

        public CreateReservationServiceCommandHandler(IRepository<ReservationService> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationServiceCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new ReservationService
            {
                City = request.City,
                Distinct = request.Distinct,
                Date = request.Date,
                Hour = request.Hour,
                Description = request.Description,
                ServiceName = request.ServiceName
            });
        }
    }
}
