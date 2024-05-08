namespace MechanicService.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogWithCategoryNameQueryHandler : IRequestHandler<GetBlogWithCategoryNameQuery, GetBlogWithCategoryNameQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetBlogWithCategoryNameQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogWithCategoryNameQueryResult> Handle(GetBlogWithCategoryNameQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBlogWithCategoryName(request.Id);
            return new GetBlogWithCategoryNameQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                CoverImageUrl = values.CoverImageUrl,
                CreatedDate = values.CreatedDate,
                CategoryID = values.CategoryID,
                Description = values.Description,
                BlogTime = values.BlogTime,
                CategoryName = values.Category.Name
            };
        }
    }
}
