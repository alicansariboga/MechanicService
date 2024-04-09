namespace MechanicService.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Banner
            {
                Title = request.Title,
                Description = request.Description,
                MediaUrl = request.MediaUrl,
                CoverImg = request.CoverImg,
            });
        }
    }
}
