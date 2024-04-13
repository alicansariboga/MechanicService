namespace MechanicService.Application.Features.Mediator.Handlers.CategoryHandlers
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryQueryResult>
    {
        private readonly IRepository<Category> _repository;

        public GetByIdCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdCategoryQueryResult> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdCategoryQueryResult
            {
                Id = values.Id,
                Name = values.Name,
            };
        }
    }
}
