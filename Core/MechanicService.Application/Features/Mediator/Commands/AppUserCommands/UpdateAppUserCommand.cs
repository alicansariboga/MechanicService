namespace MechanicService.Application.Features.Mediator.Commands.AppUserCommands
{
    public class UpdateAppUserCommand : IRequest
    {
        public int AppUserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int AppRoleID { get; set; }
    }
}
