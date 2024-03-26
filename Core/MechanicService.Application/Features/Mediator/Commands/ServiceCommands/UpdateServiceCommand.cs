namespace MechanicService.Application.Features.Mediator.Commands.ServiceCommands
{
    public class UpdateServiceCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
