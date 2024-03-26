namespace MechanicService.Application.Features.Mediator.Commands.FeatureCommands
{
    public class CreateFeatureCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
