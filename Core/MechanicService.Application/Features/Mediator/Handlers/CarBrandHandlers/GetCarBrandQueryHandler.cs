namespace MechanicService.Application.Features.Mediator.Handlers.CarBrandHandlers
{
    public class GetCarBrandQueryHandler : IRequestHandler<GetCarBrandQuery, List<GetCarBrandQueryResult>>
    {
        private readonly IRepository<CarBrand> _repository;

        public GetCarBrandQueryHandler(IRepository<CarBrand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarBrandQueryResult>> Handle(GetCarBrandQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarBrandQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                IconUrl = x.IconUrl,
            }).ToList();
        }
    }
}
