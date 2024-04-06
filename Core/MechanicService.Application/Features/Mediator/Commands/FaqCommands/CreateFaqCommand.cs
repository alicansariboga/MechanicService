namespace MechanicService.Application.Features.Mediator.Commands.FaqCommands
{
    public class CreateFaqCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
