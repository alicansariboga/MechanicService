namespace MechanicService.Application.Features.Mediator.Handlers.CarModelHandlers
{
    public class GetByIdCarModelQueryHandler : IRequestHandler<GetByIdCarModelQuery, GetByIdCarModelQueryResult>
    {
        private readonly IRepository<CarModel> _repository;

        public GetByIdCarModelQueryHandler(IRepository<CarModel> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdCarModelQueryResult> Handle(GetByIdCarModelQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdCarModelQueryResult
            {
                Id = values.Id,
                BrandID = values.BrandID,
                Name = values.Name,
                CarType = values.CarType,
            };
        }
    }
}
