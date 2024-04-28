namespace MechanicService.Application.Features.Mediator.Handlers.CustomerHandlers
{
    public class GetCustomersAllReservationsByReservationIdQueryHandler : IRequestHandler<GetCustomersAllReservationsByReservationIdQuery, List<GetCustomersAllReservationsByReservationIdQueryResult>>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomersAllReservationsByReservationIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCustomersAllReservationsByReservationIdQueryResult>> Handle(GetCustomersAllReservationsByReservationIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCustomersAllReservationsByReservationId();
            return values.Select(x => new GetCustomersAllReservationsByReservationIdQueryResult
            {
                Id = x.Id,
                RezPersonID = x.RezPersonID,
                CreateDate = x.CreateDate,
                IsApproved = x.IsApproved,
                IsCanceled = x.IsCanceled,
                PersonId = x.PersonId,
                Name = x.Name,
                Surname = x.Surname,
                IdentityNumber = x.IdentityNumber,
                Phone = x.Phone,
                PhoneOpt = x.PhoneOpt,
                Email = x.Email,
            }).ToList();
        }
    }
}
