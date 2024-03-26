namespace MechanicService.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, GetByIdAddressQueryResult>
    {
        private readonly IRepository<Address> _repository;

        public GetByIdAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdAddressQueryResult> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdAddressQueryResult
            {
                Id = values.Id,
                Description = values.Description,
                City = values.City,
                District = values.District,
                Phone = values.Phone,
                PhoneOpt = values.PhoneOpt,
                LongAddress = values.LongAddress,
                Email = values.Email,
            };
        }
    }
}
