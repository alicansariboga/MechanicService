namespace MechanicService.Application.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        AppUser GetAppUserByEmail(string mail);
        List<AppUser> GetAppUserAll();
        AppUser GetUserInfoFromToken(string token);
    }
}
