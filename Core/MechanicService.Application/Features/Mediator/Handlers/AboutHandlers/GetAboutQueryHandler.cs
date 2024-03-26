namespace MechanicService.Application.Abouts.Mediator.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                VideoUrl = x.VideoUrl
            }).ToList();
        }
    }
}
