namespace MechanicService.Application.Features.Mediator.Commands.BannerCommands
{
    public class UpdateBannerCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MediaUrl { get; set; }
        public string CoverImg { get; set; }
    }
}
