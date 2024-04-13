namespace MechanicService.Application.Features.Mediator.Handlers.ReservationPersonPersonHandlers
{
    public class CreateReservationPersonCommandHandler : IRequestHandler<CreateReservationPersonCommand>
    {
        private readonly IRepository<ReservationPerson> _repository;

        public CreateReservationPersonCommandHandler(IRepository<ReservationPerson> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationPersonCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new ReservationPerson
            {
                Name = request.Name,
                Surname = request.Surname,
                IdentityNumber = request.IdentityNumber,
                Phone = request.Phone,
                PhoneOpt = request.PhoneOpt,
                Email = request.Email
            });
        }
    }
}
