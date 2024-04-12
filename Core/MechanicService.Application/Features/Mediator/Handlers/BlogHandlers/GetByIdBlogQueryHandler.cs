namespace MechanicService.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQuery, GetByIdBlogQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetByIdBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdBlogQueryResult> Handle(GetByIdBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdBlogQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                CoverImageUrl = values.CoverImageUrl,
                CreatedDate = values.CreatedDate,
                CategoryID = values.CategoryID,
                Description = values.Description,
                BlogTime = values.BlogTime,
            };
        }
    }
}
