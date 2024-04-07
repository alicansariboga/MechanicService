namespace MechanicService.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class UpdateSocialMediaCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LinkUrl { get; set; }
        public string IconUrl { get; set; }
    }
}
