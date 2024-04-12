namespace MechanicService.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog
            {
                Title = request.Title,
                CoverImageUrl = request.CoverImageUrl,
                CreatedDate = DateTime.Now,
                CategoryID = request.CategoryID,
                Description = request.Description,
                BlogTime = request.BlogTime,
            });
        }
    }
}
