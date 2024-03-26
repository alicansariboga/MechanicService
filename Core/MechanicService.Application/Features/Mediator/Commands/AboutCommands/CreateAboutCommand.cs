namespace MechanicService.Application.Features.Mediator.Commands.AboutCommands
{
    public class CreateAboutCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}
