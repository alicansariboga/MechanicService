namespace MechanicService.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public UpdateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.RezCarID = request.RezCarID;
            values.RezPersonID = request.RezPersonID;
            values.RezServiceID = request.RezServiceID;
            values.CreateDate = request.CreateDate;
            values.IsApproved = request.IsApproved;
            values.IsCanceled = request.IsCanceled;
            await _repository.UpdateAsync(values);
        }
    }
}
