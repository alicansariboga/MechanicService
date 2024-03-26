namespace MechanicService.Application.Features.Mediator.Commands.BannerCommands
{
    public class RemoveBannerCommand : IRequest
    {
        public RemoveBannerCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
