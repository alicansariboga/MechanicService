namespace MechanicService.Application.Features.Mediator.Commands.TeamCommands
{
    public class CreateTeamCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public bool Gender { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime WorkStartDate { get; set; }
    }
}
