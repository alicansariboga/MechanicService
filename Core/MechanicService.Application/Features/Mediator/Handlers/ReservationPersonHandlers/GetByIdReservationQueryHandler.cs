namespace MechanicService.Application.Features.Mediator.Handlers.ReservationPersonPersonHandlers
{
    public class GetByIdReservationPersonQueryHandler : IRequestHandler<GetByIdReservationPersonQuery, GetByIdReservationPersonQueryResult>
    {
        private readonly IRepository<ReservationPerson> _repository;

        public GetByIdReservationPersonQueryHandler(IRepository<ReservationPerson> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdReservationPersonQueryResult> Handle(GetByIdReservationPersonQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdReservationPersonQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                Surname = values.Surname,
                IdentityNumber = values.IdentityNumber,
                Phone = values.Phone,
                PhoneOpt = values.PhoneOpt,
                Email = values.Email
            };
        }
    }
}
