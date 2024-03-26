namespace MechanicService.Application.Features.Mediator.Commands.BannerCommands
{
    public class CreateBannerCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MediaUrl { get; set; }
    }
}
