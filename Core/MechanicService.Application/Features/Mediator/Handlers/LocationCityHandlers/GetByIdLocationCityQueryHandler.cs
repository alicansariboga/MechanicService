namespace MechanicService.Application.Features.Mediator.Handlers.LocationCityHandlers
{
    public class GetByIdLocationCityQueryHandler : IRequestHandler<GetByIdLocationCityQuery, GetByIdLocationCityQueryResult>
    {
        private readonly IRepository<LocationCity> _repository;

        public GetByIdLocationCityQueryHandler(IRepository<LocationCity> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdLocationCityQueryResult> Handle(GetByIdLocationCityQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdLocationCityQueryResult
            {
                Id = values.Id,
                Name = values.Name,
            };
        }
    }
}
