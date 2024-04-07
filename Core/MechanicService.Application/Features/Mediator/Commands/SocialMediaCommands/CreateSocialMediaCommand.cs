namespace MechanicService.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand : IRequest
    {
        public string Name { get; set; }
        public string LinkUrl { get; set; }
        public string IconUrl { get; set; }
    }
}
