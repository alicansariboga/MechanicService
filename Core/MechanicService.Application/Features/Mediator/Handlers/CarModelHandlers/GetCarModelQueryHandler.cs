namespace MechanicService.Application.Features.Mediator.Handlers.CarModelHandlers
{
    public class GetCarModelQueryHandler : IRequestHandler<GetCarModelQuery, List<GetCarModelQueryResult>>
    {
        private readonly IRepository<CarModel> _repository;

        public GetCarModelQueryHandler(IRepository<CarModel> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarModelQueryResult>> Handle(GetCarModelQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarModelQueryResult
            {
                Id = x.Id,
                BrandID = x.BrandID,
                Name = x.Name,
                CarType = x.CarType,
            }).ToList();
        }
    }
}
