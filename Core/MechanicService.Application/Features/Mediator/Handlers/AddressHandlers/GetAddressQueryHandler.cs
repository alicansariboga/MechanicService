namespace MechanicService.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, List<GetAddressQueryResult>>
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                Id = x.Id,
                Description = x.Description,
                City = x.City,
                District = x.District,
                Phone = x.Phone,
                PhoneOpt = x.PhoneOpt,
                LongAddress = x.LongAddress,
                Email = x.Email,
            }).ToList();
        }
    }
}
