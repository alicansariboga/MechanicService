namespace MechanicService.Application.SocialMedias.Mediator.Handlers.SocialMediaHandlers
{
    public class GetByIdSocialMediaQueryHandler : IRequestHandler<GetByIdSocialMediaQuery, GetByIdSocialMediaQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetByIdSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdSocialMediaQueryResult> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdSocialMediaQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                LinkUrl = values.LinkUrl,
                IconUrl = values.IconUrl,
            };
        }
    }
}
