namespace MechanicService.Application.Features.Mediator.Commands.FaqCommands
{
    public class UpdateFaqCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
