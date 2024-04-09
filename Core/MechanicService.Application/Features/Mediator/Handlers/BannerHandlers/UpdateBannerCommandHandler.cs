namespace MechanicService.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Title = request.Title;
            values.Description = request.Description;
            values.MediaUrl = request.MediaUrl;
            values.CoverImg = request.CoverImg;
            await _repository.UpdateAsync(values);
        }
    }
}
