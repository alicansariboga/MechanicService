using MechanicService.Application.Interfaces.CarModelnterfaces;

namespace MechanicService.Application.Features.Mediator.Handlers.CarModelHandlers
{
    public class GetCarModelsByCityIdQueryHandler : IRequestHandler<GetCarModelsByCarBrandIdQuery, List<GetCarModelsByCarBrandIdQueryResult>>
    {
        private readonly ICarModelRepository _repository;

        public GetCarModelsByCityIdQueryHandler(ICarModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarModelsByCarBrandIdQueryResult>> Handle(GetCarModelsByCarBrandIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarModelsByCarBrandId(request.Id);
            return values.Select(x => new GetCarModelsByCarBrandIdQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                BrandID = x.BrandID,
                CarType = x.CarType,
            }).ToList();
        }
    }
}
