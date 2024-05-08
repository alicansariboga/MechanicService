
namespace MechanicService.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsQueryHandler : IRequestHandler<GetLast3BlogsQuery, List<GetLast3BlogsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsQueryResult>> Handle(GetLast3BlogsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast3Blogs();
            return values.Select(x => new GetLast3BlogsQueryResult
            {
                Id = x.Id,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                BlogTime = x.BlogTime,
                Description = x.Description
            }).ToList();
        }
    }
}
