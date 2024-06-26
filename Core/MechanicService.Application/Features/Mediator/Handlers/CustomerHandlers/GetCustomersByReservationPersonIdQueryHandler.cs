﻿namespace MechanicService.Application.Features.Mediator.Handlers.CustomerHandlers
{
    public class GetCustomersByReservationPersonIdQueryHandler : IRequestHandler<GetCustomersByReservationIdQuery, List<GetCustomersByReservationIdQueryResult>>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomersByReservationPersonIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCustomersByReservationIdQueryResult>> Handle(GetCustomersByReservationIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCustomersByReservationId();
            return values.Select(x => new GetCustomersByReservationIdQueryResult
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
