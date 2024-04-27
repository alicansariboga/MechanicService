using MechanicService.Application.Interfaces.CustomerInterfaces;

namespace MechanicService.Application.Features.Mediator.Handlers.CustomerHandlers
{
    public class GetCustomersByReservationPersonIdQueryHandler : IRequestHandler<GetCustomersByReservationPersonIdQuery, List<GetCustomersByReservationPersonIdQueryResult>>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomersByReservationPersonIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCustomersByReservationPersonIdQueryResult>> Handle(GetCustomersByReservationPersonIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCustomersByReservationPersonId();
            return values.Select(x => new GetCustomersByReservationPersonIdQueryResult
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
