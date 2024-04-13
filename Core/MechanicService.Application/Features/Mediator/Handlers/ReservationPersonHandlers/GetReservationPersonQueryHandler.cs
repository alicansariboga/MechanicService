namespace MechanicService.Application.Features.Mediator.Handlers.ReservationPersonPersonHandlers
{
    public class GetReservationPersonQueryHandler : IRequestHandler<GetReservationPersonQuery, List<GetReservationPersonQueryResult>>
    {
        private readonly IRepository<ReservationPerson> _repository;

        public GetReservationPersonQueryHandler(IRepository<ReservationPerson> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationPersonQueryResult>> Handle(GetReservationPersonQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetReservationPersonQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                IdentityNumber = x.IdentityNumber,
                Phone = x.Phone,
                PhoneOpt = x.PhoneOpt,
                Email = x.Email
            }).ToList();
        }
    }
}
