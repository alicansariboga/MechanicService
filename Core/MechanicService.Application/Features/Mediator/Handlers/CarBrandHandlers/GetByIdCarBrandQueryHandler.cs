namespace MechanicService.Application.Features.Mediator.Handlers.CarBrandHandlers
{
    namespace MechanicService.Application.Features.Mediator.Handlers.CarBrandHandlers
    {
        public class GetByIdCarBrandQueryHandler : IRequestHandler<GetByIdCarBrandQuery, GetByIdCarBrandQueryResult>
        {
            private readonly IRepository<CarBrand> _repository;

            public GetByIdCarBrandQueryHandler(IRepository<CarBrand> repository)
            {
                _repository = repository;
            }

            public async Task<GetByIdCarBrandQueryResult> Handle(GetByIdCarBrandQuery request, CancellationToken cancellationToken)
            {
                var values = await _repository.GetByIdAsync(request.Id);
                return new GetByIdCarBrandQueryResult
                {
                    Id = values.Id,
                    Name = values.Name,
                    IconUrl = values.IconUrl,
                };
            }
        }
    }
}
