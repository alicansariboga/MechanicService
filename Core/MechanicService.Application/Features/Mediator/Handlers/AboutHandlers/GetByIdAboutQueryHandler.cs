namespace MechanicService.Application.Abouts.Mediator.Handlers.AboutHandlers
{
    public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQuery, GetByIdAboutQueryResult>
    {
        private readonly IRepository<About> _repository;

        public GetByIdAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdAboutQueryResult> Handle(GetByIdAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdAboutQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Description = values.Description,
                ImageUrl = values.ImageUrl, 
                VideoUrl = values.VideoUrl
            };
        }
    }
}
