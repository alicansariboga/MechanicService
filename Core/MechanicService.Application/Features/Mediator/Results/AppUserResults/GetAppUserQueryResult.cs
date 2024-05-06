namespace MechanicService.Application.Features.Mediator.Results.AppUserResults
{
    public class GetAppUserQueryResult
    {
        public int AppUserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int AppRoleID { get; set; }
        public string AppRoleName { get; set; }
    }
}
