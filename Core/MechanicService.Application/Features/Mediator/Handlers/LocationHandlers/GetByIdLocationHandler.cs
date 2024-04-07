namespace MechanicService.Application.Locations.Mediator.Handlers.LocationHandlers
{
    public class GetByIdLocationQueryHandler : IRequestHandler<GetByIdLocationQuery, GetByIdLocationQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetByIdLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdLocationQueryResult> Handle(GetByIdLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdLocationQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                City = values.City,
                Address = values.Address,
                Phone = values.Phone,
            };
        }
    }
}
