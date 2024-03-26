namespace MechanicService.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetByIdFeatureQueryHandler : IRequestHandler<GetByIdFeatureQuery, GetByIdFeatureQueryResult>
    {
        private readonly IRepository<Feature> _repository;

        public GetByIdFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdFeatureQueryResult> Handle(GetByIdFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdFeatureQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Description = values.Description,
                IconUrl = values.IconUrl,
            };
        }
    }
}
